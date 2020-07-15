# MarkupRichTextControl
MarkupRichTextControl is a UserControl for .NET to display rich text from a markup formatted code.
The goal of this project is to build a limited markup implementation that can be used by the NoteFly note taking application for displaying notes without the need for a HTML engine.
The limited Markup implementation of MarkupRichTextControl can support:
- headings created by underscores;
- bold texts;
- italic texts;
- strike though texts;
- unordered list;
- hyperlinks;
- lines;

Not yet supported are(TODO's):
- ordered list;
- images;
- nested formatting;

Not supported are(WON'T FIX: these futures requires a lot of expensive look forward and backwards by the parser):
- tables;
- headings created by with dashes or equal characters on the next line

## Questions and Answers

###### Why is this control created?
It is created to test an implementation a .NET C# UserControl that uses the Markup language to display rich text.
It is not a full markup language is implemented but just like the markdown editor a even more limited markup language implementation.

###### Does this control also parse markup to HTML?
No, it not the goal of this project.
Markup is parsed to RichText objects that are directly displayed(GDI+) to it's own UserControl as rich text.

###### Can this control also be used as a markup language WYSIWYG editor?
Yes, that could be possible. But as said the current implementation of the markup language is deliberatively limited. 
Some features of the markup language are not support to keep the parsing of markup fast.
And some futures will not be implemented(e.g. tables) to keep the markup parser straightforward.
###### Is this still work in progress?
yes.

###### Does it currently support nested markup codes structures?
No, the markup parser does not yet support nested structures(test #7). E.g. an italic text where a part of the text is also bold this will currently be displayed incorrectly.



