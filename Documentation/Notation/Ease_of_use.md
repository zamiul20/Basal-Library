# Ease Of Use

Base of Plane:
The working area - the plane, can have a defined base, the default being <10T (denary), any other base needs to be defined.

Example, use '|' or '¦' to encapsulate:
```
|<16T|

10 = <10T 16
```

Base Pointer:
You can set a base as a variable, accessed and defined with `ণ`, use '|' or '¦' to encapsulate

Example:
```
|<16T = <ণ hT|

<ণ hT 10 = <10T 16

The letter 'h' can be replaced with anything else, apart from just a number and 'ণ' (e.g. bass7 is allowed, 7 isn't).
```

Referring to a base:
```
Of any base: {Discreted / blank},
             {Negativity / Double Negativity / blank, },
             {Base of [base_value]},
             {Velocity of [velocity] / blank}

Example:
<10 দ গ স 0.5T (Discreted Double Negative base of 10 with a velocity of 0.5)
```

Referring to a part of a number:
```
               -<   9   8   7   6   5   4   3   2   1   0   -1   -2   -3   -4   -5   -6  >- : Digit Positions
               -<  4.5  4  3.5  3  2.5  2  1.5  1  0.5  0  -0.5  -1  -1.5  -2  -2.5  -3  >- : Indexes
<10 দ গ স 0.5T     6   2   7   2   9   5   1   4   3   0.   1    2    3    1    4    5

The index is (digit_position x velocity)

E.g.:
    20000 is the digit value of position 8
    10000 is the index value of index 4
    22135.94362 is the digit value of position 7
    3162.27766 is the index value of index 3.5

base_value ^ index = index_value
```

Charactersets, set with `ৎ`, encapsulated with `¦` or `|`:
```
When using word syntax, bases that are greater than 10 tend to need to extend into an alphabet

You can define a characterset for a plane (workspace), or have it as an attribute to a base so that it can be referred to

If the characterset is a recognised standard (e.g. Unicode, ASCII, Greek Alphabet, English Alphabet), the name itself can be the reference, or you could have a list that determines the characterset.

Format:
¦ৎ {characters} {count of characters (base of plane)}¦

E.g.:
¦ৎ 0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ 36¦
```
