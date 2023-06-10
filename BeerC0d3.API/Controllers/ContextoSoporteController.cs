using AutoMapper;
using BeerC0d3.API.Dtos.chatGPT;
using BeerC0d3.API.Helpers;
using BeerC0d3.API.Services.chatGPT;
using BeerC0d3.API.Services.Sistema;
using BeerC0d3.Core.Entities.chatGPT;
using BeerC0d3.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text.Json;

namespace BeerC0d3.API.Controllers
{
   
    public class ContextoSoporteController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IChatService _chatService;
        public ContextoSoporteController(IUnitOfWork unitOfWork,IMapper mapper,IChatService chatService) {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _chatService = chatService;
        }

     
        [HttpGet("GetAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetAll()
        {
            var result = await _chatService.GetContextSupport();        
            return Ok(result);
        }
        [HttpGet("GetParents")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<GetContextSupportDto>>> GetParents()
        {
            var result = _unitOfWork.ContextoSoporte.Find(item => item.parentId == 1 && item.isActive);
            return _mapper.Map<List<GetContextSupportDto>>(result);
        }
        [HttpGet("GetByParentId/{parentId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<GetContextSupportDto>>> GetByParentId(int parentId)
        {
            var result =  _unitOfWork.ContextoSoporte.Find(item => item.parentId == parentId);
            return _mapper.Map<List<GetContextSupportDto>>(result);
        }
        [HttpGet("GetById/{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UpdateContextSupportDto>> GetById(int Id)
        {
            var result = _unitOfWork.ContextoSoporte.Find(x=>x.Id== Id).FirstOrDefault();
           // var result = await _unitOfWork.ContextoSoporte.GetByIdAsync(Id);

            return _mapper.Map<UpdateContextSupportDto>(result);
        }

        [HttpPost("Update")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Update(UpdateContextSupportDto model)
        {
            await _chatService.UpdateContextSupport(model);
            return Ok();
        }

        [HttpPost("ChatSetup")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> ChatSetup([FromBody] ChatModelDto model)
        {
            var resultContext = _unitOfWork.ContextoSoporte.Find(x => x.Id == model.contextId).FirstOrDefault();
            model.contextFile = resultContext.file;
            var result= await _chatService.ChatSetup(model);
            return Ok(result);
        }
        [HttpPost("Chat")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Chat(ChatModelDto model)
        {
            var resultContext = _unitOfWork.ContextoSoporte.Find(x => x.Id == model.contextId).FirstOrDefault();
            model.contextFile = resultContext.file;
            var result = await _chatService.Chat(model);
            return Ok(result);
        }
    }
}
