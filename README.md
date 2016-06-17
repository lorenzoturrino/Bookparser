## Description
A Visual Studio 2015 Solution to Parse a .txt file containing...words.
The program will split on any non-word character (including '_') and count the occurrences of each word, ignoring lower/uppercase versions.
Built and Tested with VS2015 (Xamarin version) and NUnit 2.6 (vanilla, no mock plugins)

This is a Tech test.


## Installation Instructions
* Download/Clone this repo
* Open the solution in Visual Studio
	OR Run bookparser/bin/release/bookparser.exe


## Run Instructions
* Run bookparser.exe.
	* Supplying no argument will load up a sample file and parse it (Through the Looking Glass by Lewis Carrol)
	* A single argument will be interpreted as a path pointing to a file, which will be loaded and parsed
	* If the first argument supplied is 'STRING', the program will load the rest of the arguments in a string and process that


## Notes on implementation:

* The main() method resides inside the BookParser class, which handles user input and console output
* Once the user input is parsed, a new instance of TextFile class is create, representing the book itself.
* While building the output string, the BookParser class call a class extension method of int, defined in the static MathHelper class, to determine if the number is prime or not.
* The words are grouped by number of occurrences, from most common to less common. This is both to improve readability for big text and to improve performance: a primality test is expensive and grouping allows the program to perform the test only once per unique number of occurrences rather than for each single word.
* Some of the calls used in the program are not strictly c# but LINQ. A good amount of research shows it being well integrated and used with the .NET framework since version 3.5 (VS 2008), so I deemed acceptable using its features.


# Notes on different approaches and performance:

* I implemented two versions of the class TextFile. V1 reads up the file/string on initialization and store the raw text in a variable. All parsing methods are only executed when called. This is the version currently used in the Bookparser class.
* V2 is similar to V1, but runs all the parsing at initialization and store the results in memory, making them accessible through properties.
* A possible V3 (not implemented) would be a static 'helper' class, containing only functions to manipulate and parse data and delegating logic + storage to the caller
* Performance-wise, V1 has the advantage of having a smaller memory footprint, as it does not memorize anything but the raw string, and being as lazy-loading as possible, executing the parsing only when required. V2 on the other hand is better optimized for reuse: by storing all the parsing results, it won't have to recompute the expensive parsing functions every time a method is called.
* A hybrid solution, lazy evaluating the parsing function with memoization, would get the best of both words, if memory utilization is not a problem.


* MathHelper contains CheckPrimality(int) and int.IsPrime() methods, returning true/false. They both use a simple check by trial algorithm.
* While a trial test has a complexity of O(sqrt(N)), the current program requires it to to run on (at most) sqrt(M) different numbers with M = total word count of the text. With N = occurrences of a given words and being N < M, the total time for primality testing will be at most O(M), in line with the other parsing operations.
* Further optimization for other uses would require the use of different, more advanced tests, either deterministic or probabilistic.
* A different approach would be to use memoization and/or a sieve method if the upper bound of N (wikipedia currently pegs the longest novel at about 2mln words)
