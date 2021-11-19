:- [input].

part_one() :-
    aoc(X), aoc(Y),
    2020 is X + Y,
    Z is X * Y,
    write(Z), nl, !.

part_two() :-
    aoc(X), aoc(Y), aoc(K),
    2020 is X + Y + K,
    Z is X * Y * K,
    write(Z), nl, !.
