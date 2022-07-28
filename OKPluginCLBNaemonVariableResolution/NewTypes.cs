using Omnikeeper.Base.Entity;
using System;
using System.Text.Json;

namespace OKPluginCLBNaemonVariableResolution
{
    [TraitEntity("monman_v2.config_rendering.naemon_variable_v1", TraitOriginType.Plugin)]
    public class NaemonVariableV1New : TraitEntity
    {
        [TraitAttribute("id", "naemon_variable.id")]
        [TraitEntityID]
        public long ID;

        [TraitAttribute("refType", "naemon_variable.reftype")]
        public string refType;

        [TraitAttribute("refID", "naemon_variable.refid")]
        public string refID;

        [TraitAttribute("name", "naemon_variable.name")]
        public string name;

        [TraitAttribute("value", "naemon_variable.value")]
        public string value;

        [TraitAttribute("precedence", "naemon_variable.precedence")]
        public long precedence;

        [TraitAttribute("isSecret", "naemon_variable.issecret")]
        public long isSecretLong;
        public bool isSecret => isSecretLong != 0L;

        public NaemonVariableV1New()
        {
            ID = 0L;
            refType = "";
            refID = "";
            name = "";
            value = "";
            precedence = 0L;
            isSecretLong = 0L;
        }
    }

    [TraitEntity("monman_v2.config_rendering.selfservice_variable", TraitOriginType.Plugin)]
    public class SelfServiceVariableNew : TraitEntity
    {
        [TraitAttribute("refType", "naemon_variable.reftype")]
        [TraitEntityID]
        public string refType;

        [TraitAttribute("refID", "naemon_variable.refid")]
        [TraitEntityID]
        public string refID;

        [TraitAttribute("name", "naemon_variable.name")]
        [TraitEntityID]
        public string name;

        [TraitAttribute("value", "naemon_variable.value")]
        public string value;

        public SelfServiceVariableNew()
        {
            refType = "";
            refID = "";
            name = "";
            value = "";
        }
    }

    [TraitEntity("monman_v2.config_rendering.naemon_instance_v1", TraitOriginType.Plugin)]
    public class NaemonInstanceV1New : TraitEntity
    {
        [TraitAttribute("id", "naemon_instance.id")]
        [TraitEntityID]
        public string ID;

        [TraitAttribute("name", "naemon_instance.name")]
        public string Name;

        [TraitRelation("tags", "has_tag", true)]
        public Guid[] Tags;

        [TraitRelation("monitoringTargets", "monitors", true)]
        public Guid[] MonitoringTargets;

        [TraitRelation("runsOn", "runs_on", true, new string[] { "tsa_cmdb.host" })]
        public Guid? RunsOn;

        public NaemonInstanceV1New()
        {
            ID = "";
            Name = "";
            Tags = Array.Empty<Guid>();
            MonitoringTargets = Array.Empty<Guid>();
            RunsOn = null;
        }
    }

    [TraitEntity("monman_v2.config_rendering.tag_v1", TraitOriginType.Plugin)]
    public class TagV1New : TraitEntity
    {
        [TraitAttribute("name", "naemon_instance_tag.tag")]
        public string Name;

        public TagV1New()
        {
            Name = "";
        }
    }

    [TraitEntity("monman_v2.config_rendering.target", TraitOriginType.Plugin)]
    public class TargetNew : TraitEntity
    {
        [TraitAttribute("id", "cmdb.id")]
        [TraitEntityID]
        public string ID;

        [TraitAttribute("resolvedVariables", "monman_v2.resolved_variables")]
        public JsonDocument ResolvedVariables;

        [TraitAttribute("useDirective", "monman_v2.use_directive")]
        public string[] UseDirective;

        [TraitRelation("monitoredByThrukHosts", "is_monitored_by_thruk_host", true, new string[] { "monman_v2.thruk_host" })]
        public Guid[] MonitoredByThrukHosts;

        public TargetNew()
        {
            ID = "";
            ResolvedVariables = null;
            UseDirective = Array.Empty<string>();
            MonitoredByThrukHosts = Array.Empty<Guid>();
        }
    }

    [TraitEntity("monman_v2.config_rendering.target_host", TraitOriginType.Plugin)]
    public class TargetHostNew : TraitEntity
    {
        [TraitAttribute("hostID", "cmdb.host.id")]
        [TraitEntityID]
        public string ID;

        [TraitAttribute("hostname", "hostname", optional: true)]
        public string? Hostname;

        [TraitAttribute("location", "cmdb.host.location", optional: true)]
        public string? Location;

        [TraitAttribute("os", "cmdb.host.os", optional: true)]
        public string? OS;

        [TraitAttribute("platform", "cmdb.host.platform", optional: true)]
        public string? Platform;

        [TraitAttribute("status", "cmdb.host.status", optional: true)]
        public string? Status;

        [TraitAttribute("customerNickname", "cmdb.host.customer")]
        public string CustomerNickname;

        [TraitAttribute("environment", "cmdb.host.environment", optional: true)]
        public string? Environment;

        [TraitAttribute("monIPAddress", "cmdb.host.mon_ip_address", optional: true)]
        public string? MonIPAddress;

        [TraitAttribute("monIPPort", "cmdb.host.mon_ip_port", optional: true)]
        public string? MonIPPort;

        [TraitAttribute("instance", "cmdb.host.instance", optional: true)]
        public string? Instance;

        [TraitAttribute("criticality", "cmdb.host.criticality", optional: true)]
        public string? Criticality;

        [TraitAttribute("foreignSource", "cmdb.host.fsource", optional: true)]
        public string? ForeignSource;

        [TraitAttribute("foreignKey", "cmdb.host.fkey", optional: true)]
        public string? ForeignKey;

        [TraitRelation("interfaces", "has_interface", true)]
        public Guid[] Interfaces;

        [TraitRelation("appSupportGroup", "belongs_to_host_app_support_group", true)]
        public Guid? AppSupportGroup;

        [TraitRelation("osSupportGroup", "belongs_to_host_support_group", true)]
        public Guid? OSSupportGroup;

        [TraitRelation("memberOfCategories", "has_category_member", false)]
        public Guid[] MemberOfCategories;

        [TraitRelation("runsOn", "runs_on", true)]
        public Guid[] RunsOn;

        public TargetHostNew()
        {
            ID = "";
            Hostname = null;
            Location = null;
            OS = null;
            Platform = null;
            Status = null;
            CustomerNickname = "";
            Environment = null;
            MonIPAddress = null;
            MonIPPort = null;
            Instance = null;
            Criticality = null;
            ForeignSource = null;
            ForeignKey = null;
            Interfaces = Array.Empty<Guid>();
            AppSupportGroup = null;
            OSSupportGroup = null;
            MemberOfCategories = Array.Empty<Guid>();
            RunsOn = Array.Empty<Guid>();
        }
    }

    [TraitEntity("monman_v2.config_rendering.target_service", TraitOriginType.Plugin)]
    public class TargetServiceNew : TraitEntity
    {
        [TraitAttribute("serviceID", "cmdb.service.id")]
        [TraitEntityID]
        public string ID;

        [TraitAttribute("name", "cmdb.service.name", optional: true)]
        public string? Name;

        [TraitAttribute("class", "cmdb.service.class", optional: true)]
        public string? Class;

        [TraitAttribute("status", "cmdb.service.status", optional: true)]
        public string? Status;

        [TraitAttribute("customerNickname", "cmdb.service.customer")]
        public string CustomerNickname;

        [TraitAttribute("environment", "cmdb.service.environment", optional: true)]
        public string? Environment;

        [TraitAttribute("criticality", "cmdb.service.criticality", optional: true)]
        public string? Criticality;

        [TraitAttribute("foreignSource", "cmdb.service.fsource", optional: true)]
        public string? ForeignSource;

        [TraitAttribute("foreignKey", "cmdb.service.fkey", optional: true)]
        public string? ForeignKey;

        [TraitAttribute("instance", "cmdb.service.instance", optional: true)]
        public string? Instance;

        [TraitAttribute("type", "cmdb.service.type", optional: true)]
        public string? Type;

        [TraitAttribute("monIPAddress", "cmdb.service.mon_ip_address", optional: true)]
        public string? MonIPAddress;

        [TraitAttribute("monIPPort", "cmdb.service.mon_ip_port", optional: true)]
        public string? MonIPPort;

        [TraitRelation("osSupportGroup", "belongs_to_service_support_group", true)]
        public Guid? OSSupportGroup;

        [TraitRelation("appSupportGroup", "belongs_to_service_app_support_group", true)]
        public Guid? AppSupportGroup;

        [TraitRelation("memberOfCategories", "has_category_member", false)]
        public Guid[] MemberOfCategories;

        [TraitRelation("runsOn", "runs_on", true)]
        public Guid[] RunsOn;

        public TargetServiceNew()
        {
            ID = "";
            Name = null;
            Class = null;
            Status = null;
            CustomerNickname = "";
            Environment = null;
            Criticality = null;
            ForeignSource = null;
            ForeignKey = null;
            Instance = null;
            Type = null;
            MonIPAddress = null;
            MonIPPort = null;
            OSSupportGroup = null;
            AppSupportGroup = null;
            MemberOfCategories = Array.Empty<Guid>();
            RunsOn = Array.Empty<Guid>();
        }
    }

    [TraitEntity("monman_v2.config_rendering.profile", TraitOriginType.Plugin)]
    public class ProfileNew : TraitEntity
    {
        [TraitAttribute("id", "naemon_profile.id")]
        [TraitEntityID]
        public long ID;

        [TraitAttribute("name", "naemon_profile.name")]
        public string Name;

        public ProfileNew()
        {
            ID = 0L;
            Name = "";
        }
    }

    [TraitEntity("monman_v2.config_rendering.module", TraitOriginType.Plugin)]
    public class ModuleNew : TraitEntity
    {
        [TraitAttribute("id", "naemon_module.id")]
        [TraitEntityID]
        public long ID;

        [TraitAttribute("name", "naemon_module.name")]
        public string Name;

        public ModuleNew()
        {
            ID = 0L;
            Name = "";
        }
    }

    [TraitEntity("monman_v2.config_rendering.category", TraitOriginType.Plugin)]
    public class CategoryNew : TraitEntity
    {
        [TraitAttribute("id", "cmdb.category.id")]
        [TraitEntityID]
        public string ID;

        [TraitAttribute("name", "cmdb.category.category")]
        public string Name;

        [TraitAttribute("tree", "cmdb.category.tree")]
        public string Tree;

        [TraitAttribute("group", "cmdb.category.group")]
        public string Group;

        [TraitAttribute("instance", "cmdb.category.instance")]
        public string Instance;

        [TraitRelation("members", "has_category_member", true)]
        public Guid[] Members;

        public CategoryNew()
        {
            ID = "";
            Name = "";
            Tree = "";
            Group = "";
            Instance = "";
            Members = Array.Empty<Guid>();
        }
    }

    [TraitEntity("monman_v2.config_rendering.customer", TraitOriginType.Plugin)]
    public class CustomerNew : TraitEntity
    {
        [TraitAttribute("id", "cmdb.customer.id")]
        [TraitEntityID]
        public string ID;

        [TraitAttribute("nickname", "cmdb.customer.nickname")]
        public string Nickname;

        [TraitRelation("associatedCIs", "is_assigned_to_customer", false)]
        public Guid[] AssociatedCIs;

        public CustomerNew()
        {
            ID = "";
            Nickname = "";
            AssociatedCIs = Array.Empty<Guid>();
        }
    }

    [TraitEntity("monman_v2.config_rendering.service_action", TraitOriginType.Plugin)]
    public class ServiceActionNew : TraitEntity
    {
        [TraitAttribute("id", "cmdb.service_action.id")]
        [TraitEntityID]
        public string ID;

        [TraitAttribute("serviceID", "cmdb.service_action.svcid")]
        public string ServiceID;

        [TraitAttribute("command", "cmdb.service_action.cmd", optional: true)]
        public string? Command;

        [TraitAttribute("commandUser", "cmdb.service_action.cmduser", optional: true)]
        public string? CommandUser;

        [TraitAttribute("type", "cmdb.service_action.type")]
        public string Type;

        public ServiceActionNew()
        {
            ID = "";
            ServiceID = "";
            Command = null;
            CommandUser = null;
            Type = "";
        }
    }

    [TraitEntity("monman_v2.config_rendering.interface", TraitOriginType.Plugin)]
    public class InterfaceNew : TraitEntity
    {
        [TraitAttribute("id", "cmdb.interface.id")]
        [TraitEntityID]
        public string ID;

        [TraitAttribute("name", "cmdb.interface.name", optional: true)]
        public string? Name;

        [TraitAttribute("lanType", "cmdb.interface.lantype", optional: true)]
        public string? LanType;

        [TraitAttribute("dnsName", "cmdb.interface.dns", optional: true)]
        public string? DnsName;

        [TraitAttribute("ip", "cmdb.interface.ip", optional: true)]
        public string? IP;

        public InterfaceNew()
        {
            ID = "";
            Name = null;
            LanType = null;
            DnsName = null;
            IP = null;
        }
    }

    [TraitEntity("monman_v2.config_rendering.group", TraitOriginType.Plugin)]
    public class GroupNew : TraitEntity
    {
        [TraitAttribute("id", "cmdb.group.id")]
        [TraitEntityID]
        public string ID;

        [TraitAttribute("name", "cmdb.group.name")]
        public string Name;

        public GroupNew()
        {
            ID = "";
            Name = "";
        }
    }
}
