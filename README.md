# MarkupRichTextControl
MarkupRichTextControl is a UserControl for .NET to display rich text from a markup formatted code.
The goal of this project is to build a limited markup implementation that can be used by the NoteFly note taking application for storing and displaying notes.
The limited Markup implementation of MarkupRichTextControl can support:
- bold texts;
- italic texts;
- strike though texts;
- unordered list;
- headings;
- hyperlinks;
- lines;

Not supported are:
- headings, created by with dashes or equal characters on the next line;
- tables;
- images;

## Questions and Answers
###### Why is this control created?
It is created to test an implementation a .NET / C# user control that uses the Markup language to display rich text.
###### Can this control also be used as a markup language WYSIWYG editor?
Yes, that could be possible if extended. But the current implementation of the markup language is limited. 
Some features of the markup language are not working, like tables and images.
###### Does it currently support nested markup codes structures?
No, the markup parser does not support nested structures. E.g. an italic text where a part of the text is also bold this will currently be displayed incorrectly.
