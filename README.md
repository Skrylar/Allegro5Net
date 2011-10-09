
Allegro5Net
===========

A simple object-oriented wrapper for the Allegro (version 5.x) game library,
which makes it easy to use from C#.

Use
---

Compile the solution for whichever .NET profile/version you need, and then
reference in your own projects.  If desired you may also transplant the
source code to your project or compile it as a netmodule to avoid having
an extra dependency.  I (Skrylar) won't provide official binaries until the
wrapping is fully completed (it simply makes no sense to do so until then.)

Be warned that T4 is used for generating boilerplate; if you see ".tt" files
and ".cs" files of the same name, you will have to edit the ".tt" template
file.  CS files of these templates are provided solely for convenience of
not needing to run the generator (at the time of writing SharpDevelop only
parses a T4 file when that particular ".tt" is saved.)

Development
-----------

Allegro5Net is developed using SharpDevelop and SublimeEdit.  Sublime provides
multi-caret editing which makes one-shot transformation of text a breeze
which was heavily used when adapting method headers; Mono.TextTemplate is used
by SharpDevelop to provide an OSS-friendly version of Microsoft's T4 which is
also used for generating a lot of boilerplate code in Allegro5Net.

Allegro5Net has Mono in mind, but has yet to be tested with it.  Use of anything
higher than .NET 3.5 is discouraged since Ubuntu/Gnome distros don't support
C# 4 right now.


Special Thanks
--------------

Shawn Hargreaves, for writing Allegro.
Allegro Team et all, for updating and maintaining Allegro.
SharpDevelop Team & Contributors, for writing the SharpDevelop IDE.
Jon Skinner, for writing SublimeEdit.
Bram Moolenaar et all, for the Vim editor.

License
-------

I've never been a fan of wrappers having cumbersome licensing, ESPECIALLY ones
worse than the library that they wrap! Allegro5Net is provided under the
2-clause BSD license same as Allegro 5.

BSD
---

Copyright (c) 2011, Joshua A. Cearley
All rights reserved.

Redistribution and use in source and binary forms, with or without modification, are permitted provided that the following conditions are met:

1. Redistributions of source code must retain the above copyright notice, this list of conditions and the following disclaimer.
2. Redistributions in binary form must reproduce the above copyright notice, this list of conditions and the following disclaimer in the documentation and/or other materials provided with the distribution.

THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

