﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Assignment2.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Assignment2.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to YYC,Calgary International Airport
        ///YEG,Edmonton International Airport
        ///YUL,Montreal Pierre Elliott Trudeau International Airport
        ///YOW,Ottawa Macdonald-Cartier International Airport
        ///YYZ,Toronto Pearson International Airport
        ///YVR,Vancouver International Airport
        ///YWG,Winnipeg James Armstrong Richardson International Airport
        ///ATL,Hartsfield-Jackson Atlanta International Airport
        ///PEK,Beijing Capital International Airport
        ///DXB,Dubai International Airport
        ///HKG,Hong Kong International Airport
        ///LHR,London Heathrow  [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string airports {
            get {
                return ResourceManager.GetString("airports", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to TB-4017,Try a Bus Airways,ATL,FRA,Monday,18:30,174,1444.00
        ///SL-4367,Scare Airlines,YYC,YEG,Thursday,21:30,50,270.00
        ///AL-6488,Always Late Airlines,PEK,YVR,Saturday,0:30,292,4710.00
        ///SL-9996,Scare Airlines,DFW,FRA,Sunday,21:00,255,1188.00
        ///SW-3491,Sprawl Airways,YVR,PEK,Thursday,8:30,255,1086.00
        ///SL-9465,Scare Airlines,YEG,CDG,Sunday,7:15,292,1456.00
        ///SL-2797,Scare Airlines,YOW,CDG,Saturday,23:30,255,1060.00
        ///MA-6635,Mediocre Airlines,YUL,DFW,Friday,15:00,169,449.00
        ///CA-1858,Conned Air,YOW,AMS,Tuesday,20:15,2 [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string flights {
            get {
                return ResourceManager.GetString("flights", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to .
        /// </summary>
        internal static string reservations {
            get {
                return ResourceManager.GetString("reservations", resourceCulture);
            }
        }
    }
}
