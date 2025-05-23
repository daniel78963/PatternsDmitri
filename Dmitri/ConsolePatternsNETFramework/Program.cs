﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ConsolePatternsNETFramework
{
    class Program
    {
        //BUILDER
        //static void Main(string[] args)
        //{
        //    // if you want to build a simple HTML paragraph using StringBuilder
        //    var hello = "hello";
        //    var sb = new StringBuilder();
        //    sb.Append("<p>");
        //    sb.Append(hello);
        //    sb.Append("</p>");
        //    Console.WriteLine(sb);
        //    //d

        //    // now I want an HTML list with 2 words in it
        //    var words = new[] { "hello", "world" };
        //    sb.Clear();
        //    sb.Append("<ul>");
        //    foreach (var word in words)
        //    {
        //        sb.AppendFormat("<li>{0}</li>", word);
        //    }
        //    sb.Append("</ul>");
        //    Console.WriteLine(sb);

        //    // ordinary non-fluent builder
        //    var builder = new HtmlBuilder("ul");
        //    builder.AddChild("li", "hello");
        //    builder.AddChild("li", "world");
        //    Console.WriteLine(builder.ToString());

        //    // fluent builder
        //    sb.Clear();
        //    builder.Clear(); // disengage builder from the object it's building, then...
        //    builder.AddChildFluent("li", "hello").AddChildFluent("li", "world");
        //    Console.WriteLine(builder);

        //}

        //Liskov incomplete 
        static public int Area(Rectangle rectangle) => rectangle.Width * rectangle.Heigth;
        static void Main(string[] args)
        {
            Rectangle rectangle = new Rectangle(2, 3);
            Console.WriteLine($"{rectangle} has an area {Area(rectangle)}");
        }
    }

    // public class DemoRectangule()
    //{
    //    static public int Area(Rectangle rectangle) => rectangle.Width * rectangle.Heigth;
    //}

    class HtmlElement
    {
        public string Name, Text;
        public List<HtmlElement> Elements = new List<HtmlElement>();
        private const int indentSize = 2;

        public HtmlElement()
        {

        }

        public HtmlElement(string name, string text)
        {
            Name = name;
            Text = text;
        }

        private string ToStringImpl(int indent)
        {
            var sb = new StringBuilder();
            var i = new string(' ', indentSize * indent);
            sb.Append($"{i}<{Name}>\n");
            if (!string.IsNullOrWhiteSpace(Text))
            {
                sb.Append(new string(' ', indentSize * (indent + 1)));
                sb.Append(Text);
                sb.Append("\n");
            }

            foreach (var e in Elements)
                sb.Append(e.ToStringImpl(indent + 1));

            sb.Append($"{i}</{Name}>\n");
            return sb.ToString();
        }

        public override string ToString()
        {
            return ToStringImpl(0);
        }
    }

    class HtmlBuilder
    {
        private readonly string rootName;

        public HtmlBuilder(string rootName)
        {
            this.rootName = rootName;
            root.Name = rootName;
        }

        // not fluent
        public void AddChild(string childName, string childText)
        {
            var e = new HtmlElement(childName, childText);
            root.Elements.Add(e);
        }

        public HtmlBuilder AddChildFluent(string childName, string childText)
        {
            var e = new HtmlElement(childName, childText);
            root.Elements.Add(e);
            return this;
        }

        public override string ToString()
        {
            return root.ToString();
        }

        public void Clear()
        {
            root = new HtmlElement { Name = rootName };
        }

        HtmlElement root = new HtmlElement();
    }
}
