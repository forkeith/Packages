/// SYNTAX TEST "Packages/C#/C#.sublime-syntax"

"short unicode \u1234";
///<- string.quoted.double.cs
///            ^^^^^^ constant.character.escape.cs

"long unicode \U12345678";
///<- string.quoted.double.cs
///           ^^^^^^^^^^ constant.character.escape.cs

"invalid escape \u12";
///<- string.quoted.double.cs
///             ^ invalid.illegal.lone-escape.cs

"simple escapes \' \" \\ \0 \a \b \f \n \r \t \v";
///<- string.quoted.double.cs
///             ^^ constant.character.escape.cs
///                ^^ constant.character.escape.cs
///                   ^^ constant.character.escape.cs
///                      ^^ constant.character.escape.cs
///                         ^^ constant.character.escape.cs
///                            ^^ constant.character.escape.cs
///                               ^^ constant.character.escape.cs
///                                  ^^ constant.character.escape.cs
///                                     ^^ constant.character.escape.cs
///                                        ^^ constant.character.escape.cs
///                                           ^^ constant.character.escape.cs

var literal = "foo";
///           ^^^^^ string.quoted.double
var interpolated_none = $"foo";
///                     ^^^^^^ meta.string.interpolated.cs string.quoted.double.cs
var interpolated_yes = $"foo {bar} foo";
///                    ^^^^^^^^^^^^^^^^ meta.string.interpolated.cs
var verbatim_singleline = @"foo";
///                       ^^^^^^ string.quoted.double.raw.cs
var verbatim_singleline_interpolated_none = $@"foo bar";
///                                         ^^^^^^^^^^^ meta.string.interpolated.cs string.quoted.double.raw.cs
var verbatim_singleline_interpolated_yes = $@"foo {bar} foo";
///                                        ^^^^^^^ string.quoted.double.raw.cs
///                                        ^^^^^^^^^^^^^^^^^ meta.string.interpolated.cs
var verbatim_multiline = @"foo bar
///                      ^^^^^^^^^^ string.quoted.double.raw.cs
baz";
var verbatim_multiline_interpolated_none = $@"foo bar
///                                        ^^^^^^^^^^^ meta.string.interpolated.cs string.quoted.double.raw.cs
baz";
var verbatim_multiline_interpolated_yes = $@"foo {bar}
///                                       ^^^^^^ string.quoted.double.raw.cs
///                                       ^^^^^^^^^^^^ meta.string.interpolated.cs
baz";

    "{32F31D43-81CC-4C15-9DE6-3FC5453562B6}"
/// ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^ string.quoted.double
///  ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^ constant.other.guid

Regex rx = new Regex(@"\b(?<word>\w+)\s+(\k<word>)\b", RegexOptions.Compiled | RegexOptions.IgnoreCase);
///            ^^^^^ meta.instance support.type
///                    ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^ meta.string source.regexp
///                                                 ^ meta.string punctuation.definition.string.end - source.regexp
///                    ^^ keyword.control.anchor
Match m = Regex.Match(input, @"\ba\w*\b", RegexOptions.IgnoreCase);
///       ^^^^^ meta.function-call support.class
///            ^ meta.function-call punctuation.accessor.dot.namespace
///             ^^^^^ meta.function-call variable.function
///                  ^ meta.group punctuation.section.group.begin
///                            ^^^^^^^^ meta.string source.regexp
///                                    ^ meta.string string.quoted.double.raw punctuation.definition.string.end - source.regexp

replaced = Regex.Replace(some_value, "(?!^)([A-Z])", " $1");
///        ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^ meta.function-call
///        ^^^^^ support.class
///             ^ punctuation.accessor.dot.namespace
///              ^^^^^^^ variable.function
///                     ^ punctuation.section.group.begin
///                      ^^^^^^^^^^ variable.other
///                                ^ punctuation.separator.argument
///                                  ^ meta.string string.quoted.double punctuation.definition.string.begin
///                                   ^^^^^^^^^^^^ meta.string source.regexp
///                                               ^ meta.string string.quoted.double punctuation.definition.string.end - source.regexp
///                                                ^ punctuation.separator.argument

Regex rx = new Regex(@"\bincomplete-missing-paren\b"
///        ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^ meta.instance
///        ^^^ keyword.operator.new
///            ^^^^^ support.type
///                  ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^ meta.string
///                  ^^ string.quoted.double.raw punctuation.definition.string.begin
///                    ^^^^^^^^^^^^^^^^^^^^^^^^^^^^ source.regexp
///                                                ^ punctuation.definition.string.end - source.regexp
///                    ^^ keyword.control.anchor

expression_after_incomplete_statement = "12";
/// ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^ meta.instance meta.group
/// ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^ variable.other
///                                   ^ keyword.operator.assignment
///                                     ^^^^ meta.string string.quoted.double
///                                         ^ invalid.illegal.expected-close-paren
///                                          ^ - meta.instance - meta.group
