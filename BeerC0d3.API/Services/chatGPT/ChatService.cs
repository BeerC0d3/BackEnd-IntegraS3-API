using BeerC0d3.API.Dtos.chatGPT;
using BeerC0d3.API.Helpers;
using BeerC0d3.API.Models;
using BeerC0d3.Core.Entities.chatGPT;
using BeerC0d3.Core.Interfaces;
using Microsoft.Extensions.Options;
using Serilog;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace BeerC0d3.API.Services.chatGPT
{
    public class ChatService : IChatService
    {
        private readonly IOptions<chatSetting> _chatSetting;
        //private readonly HttpClient _httpClient;
        private readonly IUnitOfWork _unitOfWork;
        public ChatService(IOptions<chatSetting> chatSetting, IUnitOfWork unitOfWork)
        {
            // _httpClient = httpClient;

            _chatSetting = chatSetting;
            _unitOfWork = unitOfWork;

        }
        public async Task<ChatGptResponse> Chat(ChatModelDto model)
        {
            HttpClient _httpClient = new HttpClient();
            var content = new StringContent(
                        JsonSerializer.Serialize(model),
                        Encoding.UTF8,
                        "application/json");
            var request = await _httpClient.PostAsync($"{_chatSetting.Value.urlChatGPTService}chat",content);
            request.EnsureSuccessStatusCode();
            var result = JsonSerializer.Deserialize<ChatGptResponse>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
            return result;
        }

        public async Task<ChatModelDto> ChatSetup(ChatModelDto model)
        {

            HttpClient _httpClient = new HttpClient();
           
            var content = new StringContent(
                         JsonSerializer.Serialize(model),
                         Encoding.UTF8,
                         "application/json");

            var request = await _httpClient.PostAsync($"{_chatSetting.Value.urlChatGPTService}chat/setup", content);
            request.EnsureSuccessStatusCode();
            var result = JsonSerializer.Deserialize<ChatModelDto>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );

            return result;
        }
        public async Task<ICollection<ContextSupportDto>> GetContextSupport()
        {

            var contextSupportList = _unitOfWork.ContextoSoporte.Find(item => item.isActive).ToList();
            var contextProcesados = CreaContextSupport(contextSupportList);

            return contextProcesados;
        }

        public async Task UpdateContextSupport(UpdateContextSupportDto model)
        {
            try
            {

                var resultContext = _unitOfWork.ContextoSoporte.Find(item => item.Id == model.Id).FirstOrDefault();
                if (resultContext == null)
                {
                    throw new Exception("No existe el id");
                }

                if (!string.IsNullOrEmpty(model.Logo))
                {
                    var logo = await BeerC0d3.Firebase.FirebaseStorageManager.UploadFile(new MemoryStream(Convert.FromBase64String(model.Logo)), new Firebase.FileDTO { FolderName = "Logo", FileName = model.NameLogo });
                    resultContext.logo = logo;
                }
                if (!string.IsNullOrEmpty(model.File))
                {
                    var context = await BeerC0d3.Firebase.FirebaseStorageManager.UploadFile(new MemoryStream(Convert.FromBase64String(model.File)), new Firebase.FileDTO { FolderName = "File", FileName = model.NameFile });
                    resultContext.file = context;
                }

                resultContext.name = model.Name;
                _unitOfWork.ContextoSoporte.Update(resultContext);
                await _unitOfWork.SaveAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        private ICollection<ContextSupportDto> CreaContextSupport(ICollection<ContextSupport> listContext)
        {
            ICollection<ContextSupportDto> listContextSup = new List<ContextSupportDto>();
            ContextSupport contextOrigen = listContext.Where(item => item.parentId == 0).FirstOrDefault();
            if (contextOrigen == null)
                throw new Exception("No se encontró el contextSupport origen.");


            ContextSupportDto contextDto = new ContextSupportDto();
            contextDto.Id = contextOrigen.Id;
            contextDto.Name = contextOrigen.name;
            contextDto.Logo = contextOrigen.logo;
            contextDto.File = contextOrigen.file;
            contextDto.ContextSupportChildren = CreaContextSupport(listContext, contextDto.Id);
            listContextSup.Add(contextDto);

            return listContextSup;
        }

        private ICollection<ContextSupportDto> CreaContextSupport(ICollection<ContextSupport> listContext, int parentId)
        {
            ICollection<ContextSupportDto> listContextDto = new List<ContextSupportDto>();

            List<ContextSupport> listContextHijos = listContext.Where(item => item.parentId == parentId).ToList();
            foreach (ContextSupport contextHijo in listContextHijos)
            {
                ContextSupportDto contextDto = new ContextSupportDto();
                contextDto.Id = contextHijo.Id;
                contextDto.Name = contextHijo.name;
                contextDto.Logo = contextHijo.logo;
                contextDto.File = contextHijo.file;
                contextDto.ContextSupportChildren = CreaContextSupport(listContext, contextDto.Id);
                listContextDto.Add(contextDto);
            }


            return listContextDto;

        }


    }
}
