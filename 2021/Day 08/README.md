# Day 8
Very interesting puzzle today, and I am still loving the problem descriptions! I think this is the entire reason why AOC (and oftentimes [Kattis](https://open.kattis.com)) is so cozy, because you get to feel like you are actually helping out with something.

I will also take a break from AOC until at least Tuesday, because I really need to study for my exams, and AOC has unfortunately given me proper tunnel vision.

## The solution
I had to re-read the problem description a couple of times, and relief washed over me in an awesome wave when I realised how simple part 1 actually was. Just check if any of the strings on the right side of the delimiter is of size 2, 3, 4 or 7, and if so, add 1 to a counter. Lastly we just print our count.

For part 2 on the other hand, I was not nearly as lucky. I ended up with 100 lines of code for the first time this December (no no, this is a bad thing!), by doing some pattern matching. We already know which ones are 1, 4, 7 and 8, so at least we could work from there. 2, 3 and 5 contain 5 chars, while 0, 6 and 9 contain 6. Now we can get 3 from matching 1 (both fill their right sides), 9 from matching 3 (both fill their right sides and middle). We can then get 0 from 1 (both fill their right side) and 5 from 6 (match upper left side). When we get a digit, we put its encoding on its respective index in a list, and later run this list against the right hand side of the original input. For every match here, add the digit to a string, before adding the final string (casted to an int) to a counter. Lastly we just print our count, again.