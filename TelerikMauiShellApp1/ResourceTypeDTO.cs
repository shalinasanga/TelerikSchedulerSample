using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelerikMauiShellApp1
{
    public enum ResourceTypeDTO
    {
        tDummy,
        tOrg,
        tLoc,
        tEquip,
        tUser,
        tContact,
        tWaste,
        tGroup,
        tEvent,
        tAwayUser,
        tFavourites,
        tMySelf,
        tUserContact,
        AllContact,
        ExchangeUsers,
        All,
        tCouncil = 23
    };
    public class ResourceItemDTO
    {
        public string ResourceCaption { get; set; }
        public ResourceTypeDTO ResourceType { get; set; }
        public Guid ResourceId { get; set; }
        public Guid Organizationid { get; set; }
        public string EMail { get; set; }
        public string Mobile { get; set; }

        public bool IsSelect { get; set; }

        public bool IsDoubleBookingAllowed { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Address { get; set; }
        public bool CanPlan { get; set; }
        public bool HasFunction { get; set; }
        public bool? AllowPublish { get; set; }
        public Guid MappedLocationId { get; set; }
        public string MappedLocationName { get; set; }
    }
    public class EventsResourceItemDTO : ResourceItemDTO
    {
        public int TempResourceId { get; set; }

        public bool IncludeGroups { get; set; }

        public bool IncludeUsers { get; set; }

        public bool IncludeEquipment { get; set; }

        public bool IncludeLocations { get; set; }
        public bool IncludeCouncilGroups { get; set; }

    }

    public class EventsOrganizationItemDTO : EventsResourceItemDTO
    {
        public EventsResourceItemDTO ParentItem { get; set; }

        public bool IncludeOrganizationEvents { get; set; } = true;
    }
    public class OffsetResourceItem : EventsResourceItemDTO
    {

        public int OffsetStart { get; set; }

        public int OffsetEnd { get; set; }

        public int? Status { get; set; }

        public List<Guid> FunctionToEventId { get; set; }

        public bool InvitationSent { get; set; }
        public bool? IsHeatingSet { get; set; }
        public int? HeatingTemperature { get; set; }

        public OffsetResourceItem()
        {
            FunctionToEventId = new List<Guid>();
        }
    }
}
