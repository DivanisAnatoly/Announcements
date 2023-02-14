using Announcements.Application.Interfaces.Services.Announcements;
using Announcements.Application.Interfaces.Services.Announcements.Contracts;
using Announcements.Application.RequestModels;
using Announcements.Application.RequestModels.Announcement;
using Announcements.Application.RequestModels.Comment;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading;
using System.Threading.Tasks;


namespace Announcements.API.Controllers.Announcements
{

    /// <summary>
    /// Контролер объявлений
    /// </summary>
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AnnouncementsController : ControllerBase
    {
        private readonly IAnnouncementService _announcementService;
        private readonly IMapper _mapper;


        /// <summary>
        /// Конструктор
        /// </summary>
        public AnnouncementsController(IAnnouncementService announcementService, IMapper mapper)
        {
            _announcementService = announcementService;
            _mapper = mapper;
        }


        /// <summary>
        /// Возвращает объявления постранично
        /// </summary>
        [HttpGet("GetPaged")]
        public async Task<IActionResult> GetPagedAnnouncements([FromQuery] GetPagedAnnouncementsRequest request, CancellationToken cancellationToken)
        {
            var announcementsPage = await _announcementService.GetAnnouncementsPaged(request, cancellationToken);

            var metadata = new
            {
                announcementsPage.TotalCount,
                announcementsPage.PageSize,
                announcementsPage.CurrentPage,
                announcementsPage.TotalPages,
                announcementsPage.HasNext,
                announcementsPage.HasPrevious
            };

            Response.Headers.Add("User-Pagination", JsonConvert.SerializeObject(metadata));
            return Ok(announcementsPage);
        }


        /// <summary>
        /// Создает новое объявление
        /// </summary>
        [HttpPost]
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> CreateAnnouncement([FromBody] AnnouncementCreateRequest AddAnnouncementRequest, CancellationToken cancellationToken)
        {
            CreateAnnouncementDTO.Request request = _mapper.Map<CreateAnnouncementDTO.Request>(AddAnnouncementRequest);
            var response = await _announcementService.CreateAnnouncement(request, cancellationToken);
            return Ok(response);
        }


        /// <summary>
        /// Возвращает объявление по идентификатору
        /// </summary>
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> GetAnnouncement(int id, CancellationToken cancellationToken)
        {
            var response = await _announcementService.GetAnnouncement(id, cancellationToken);
            return Ok(response);
        }


        /// <summary>
        /// Редактирует объявление
        /// </summary>
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> EditAnnouncement([FromForm] AnnouncementEditRequest editRequest, CancellationToken cancellationToken)
        {
            EditAnnouncementDTO.Request request = _mapper.Map<EditAnnouncementDTO.Request>(editRequest);
            var response = await _announcementService.EditAnnouncement(editRequest.ID, request, cancellationToken);
            return Ok(response);
        }


        /// <summary>
        /// Удаляет объявление
        /// </summary>
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> DeleteAnnouncement(int id, CancellationToken cancellationToken)
        {
            await _announcementService.DeleteAnnouncement(id, cancellationToken);
            return Ok("Announcement was successfully deleted");
        }


        /// <summary>
        /// Возвращает комментарии объявления
        /// </summary>
        [HttpGet("{id}/comments")]
        public async Task<IActionResult> GetAnnouncementComments(int id, [FromQuery] GetPagedCommentsRequest request, CancellationToken cancellationToken)
        {
            var announCommentsPage = await _announcementService.GetAnnouncementCommentsPaged(id, request, cancellationToken);

            var metadata = new
            {
                announCommentsPage.TotalCount,
                announCommentsPage.PageSize,
                announCommentsPage.CurrentPage,
                announCommentsPage.TotalPages,
                announCommentsPage.HasNext,
                announCommentsPage.HasPrevious
            };

            Response.Headers.Add("User-Pagination", JsonConvert.SerializeObject(metadata));
            return Ok(announCommentsPage);
        }

    }

}