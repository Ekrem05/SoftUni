using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Differencing;
using System.Text;
using System;

namespace Homies.Models.ViewModels
{
    public class EventDetailsViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Start { get; set; } = null!;

        public string End { get; set; } = null!;
        public string Organiser { get; set; } = null!;

        public string Type { get; set; } = null!;

        public string CreatedOn { get; set; } = null!;
    }
}
    //< h3 class= "card-title text-center" > @Model.Name </ h3 >
    //        < p class= "mb-0" >< span class= "fw-bold" > Description: </ span > @Model.Description </ p >
    //        < p class= "mb-0" >< span class= "fw-bold" > Starting time: </ span > @Model.Start </ p >
    //        < p class= "mb-0" >< span class= "fw-bold" > Estimated ending time: </ span > @Model.End </ p >
    //        < p class= "mb-0" >< span class= "fw-bold" > Organiser: </ span > @Model.Organiser </ p >
    //        < p class= "mb-0" >< span class= "fw-bold" > Created on: </ span > @Model.CreatedOn </ p >
    //        < p class= "mb-0" >< span class= "fw-bold" > Type: </ span > @Model.Type </ p >
    //    </ div >

    //    < a asp - controller = "Event" asp - action = "All" class= "btn btn-warning mb-2 w-100 p-3 fw-bold" > Back to All Events</a>
    //    @if (User.Identity.Name == Model.Organiser)
    //    {
    //        <a asp-controller="Event" asp-action="Edit" asp-route-id="@Model.Id" class= "btn btn-warning mb-2 w-100 p-3 fw-bold" > Edit </ a >
    //    }