using System.Collections.Generic;
using VirtoCommerce.Platform.Core.Settings;

namespace CustomerReviewModule.Core
{
    public static class ModuleConstants
    {
        public static class Security
        {
            public static class Permissions
            {
                public const string Access = "customerReviewModule:access";
                public const string Create = "customerReviewModule:create";
                public const string Read = "customerReviewModule:read";
                public const string Update = "customerReviewModule:update";
                public const string Delete = "customerReviewModule:delete";

                public static string[] AllPermissions = { Read, Create, Access, Update, Delete };
            }
        }

        public static class Settings
        {
            public static class General
            {
                public static SettingDescriptor CustomerReviewModuleEnabled = new SettingDescriptor
                {
                    Name = "CustomerReviewModule.CustomerReviewModuleEnabled",
                    GroupName = "Store|General",
                    ValueType = SettingValueType.Boolean,
                    DefaultValue = "true"
                };

                public static IEnumerable<SettingDescriptor> AllSettings
                {
                    get
                    {
                        yield return CustomerReviewModuleEnabled;
                    }
                }
            }

            public static IEnumerable<SettingDescriptor> AllSettings
            {
                get
                {
                    return General.AllSettings;
                }
            }
        }

    }
}
