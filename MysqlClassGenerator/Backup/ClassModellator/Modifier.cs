using System;
using System.Collections.Generic;
using System.Text;

namespace ClassModellator.ModifierManager
{
    /// <summary>
    /// Modifier Modellator
    /// </summary>
    public class Modifier
    {
        String _value;

        public String Value
        {
            get { return _value; }
            set { _value = value; }
        }

        String _destription;

        public String Destription
        {
            get { return _destription; }
            set { _destription = value; }
        }

        public Modifier()
        {
        
        }

        public Modifier(String Type, String Destription)
        {
            this._value = Type;

            this.Destription = Destription;
        }

    }


    /// <summary>
    /// List of Scope Modifiers (public,private,internal,protected,internal protected)
    /// http://msdn.microsoft.com/en-us/library/6tcf2h8w(VS.71).aspx
    /// </summary>
    public static class ListAccessModifiers
    {
        /// <summary>
        /// Specify the declared accessibility of types and type members.
        /// </summary>
        public static Modifier PUBLIC = new Modifier("public", "Specify the declared accessibility of types and type members.");
        /// <summary>
        /// Specify the declared accessibility of types and type members.
        /// </summary>
        public static Modifier PRIVATE = new Modifier("private", "Specify the declared accessibility of types and type members.");
        /// <summary>
        /// Specify the declared accessibility of types and type members.
        /// </summary>
        public static Modifier INTERNAL = new Modifier("internal", "Specify the declared accessibility of types and type members.");
        /// <summary>
        /// Specify the declared accessibility of types and type members.
        /// </summary>
        public static Modifier PROTECTED = new Modifier("protected", "Specify the declared accessibility of types and type members.");


        public static Modifier INTERNAL_PROTECTED = new Modifier("internal protected", null);

        public static Modifier PUBLIC_PARTIAL = new Modifier("public partial", null);


        public static List<String> toListString()
        {
            List<String> ListAccessModifiers = new List<String>();
            ListAccessModifiers.Add("public");
            ListAccessModifiers.Add("private");
            ListAccessModifiers.Add("internal");
            ListAccessModifiers.Add("protected");
            ListAccessModifiers.Add("internal protected");
            ListAccessModifiers.Add("public partial");
            return ListAccessModifiers;

        }
    }

    /// <summary>
    /// List of Scope Modifiers (public,private,internal,protected,internal protected)
    /// http://msdn.microsoft.com/en-us/library/6tcf2h8w(VS.71).aspx
    /// </summary>
    public static class ListModifiers
    {

        /// <summary>
        /// Indicate that a class is intended only to be a base class of other classes. 
        /// </summary>
        public static Modifier ABSTRACT = new Modifier("abstract", " Indicate that a class is intended only to be a base class of other classes. ");
        /// <summary>
        /// Specify that the value of the field or the local variable cannot be modified.
        /// </summary>
        public static Modifier CONST = new Modifier("const", "Specify that the value of the field or the local variable cannot be modified.");

        /// <summary>
        /// Declare an event.
        /// </summary>
        public static Modifier EVENT = new Modifier("event", "Declare an event.");
        /// <summary>
        /// Indicate that the method is implemented externally. 
        /// </summary>
        public static Modifier EXTERN = new Modifier("extern", "Indicate that the method is implemented externally. ");
        /// <summary>
        /// Provide a new implementation of a virtual member inherited from a base class. 
        /// </summary>
        public static Modifier OVERRIDE = new Modifier("override", "Provide a new implementation of a virtual member inherited from a base class. ");
        /// <summary>
        /// Declare a field that can only be assigned values as part of the declaration or in a constructor in the same class.
        /// </summary>
        public static Modifier READONLY = new Modifier("readonly", "Declare a field that can only be assigned values as part of the declaration or in a constructor in the same class.");
        /// <summary>
        /// Specify that a class cannot be inherited. 
        /// </summary>
        public static Modifier SEALED = new Modifier("sealed", "Specify that a class cannot be inherited. ");
        /// <summary>
        /// Declare a member that belongs to the type itself rather than to a specific object.
        /// </summary>
        public static Modifier STATIC = new Modifier("static", "Declare a member that belongs to the type itself rather than to a specific object.");
        /// <summary>
        /// Declare an unsafe context.
        /// </summary>
        public static Modifier UNSAFE = new Modifier("unsafe", "Declare an unsafe context.");
        /// <summary>
        /// Declare a method or an accessor whose implementation can be changed by an overriding member in a derived class.
        /// </summary>
        public static Modifier VIRTUAL = new Modifier("virtual", "Declare a method or an accessor whose implementation can be changed by an overriding member in a derived class.");
        /// <summary>
        /// Indicate that a field can be modified in the program by something such as the operating system, the hardware, or a concurrently executing thread. 
        /// </summary>
        public static Modifier VOLATILE = new Modifier("volatile", " Indicate that a field can be modified in the program by something such as the operating system, the hardware, or a concurrently executing thread. ");


        public static List<String> toListString()
        {
            List<string> ListModifiers = new List<string>();
            ListModifiers.Add("abstract");
            ListModifiers.Add("const");
            ListModifiers.Add("event");
            ListModifiers.Add("extern");
            ListModifiers.Add("override");
            ListModifiers.Add("readonly");
            ListModifiers.Add("sealed");
            ListModifiers.Add("static");
            ListModifiers.Add("unsafe");
            ListModifiers.Add("virtual");
            ListModifiers.Add("volatile");

            return ListModifiers;

        }

    }

    

}
