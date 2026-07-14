# Ripllification

This section explains how to make a number have echo (see \Documentation\Base_Attributes\Echo).

Echo types:
Regular: The type we use everyday, 
Positive, where the ripple [n] is satisfies the equation: ( ⌊n⌋ = n ≠ 0 ):
    +n,
    -n;
Negative, where the ripple [n] is satisfies the equation: ( ⌊n⌋ = n ≠ 0 ):
    +n,
    -n

Echo of positive and negative arrange the number based on digit positions, separated with a `জ`

Converting from a normal number to have a positive echo with a ripple of +3 - `<RT to <R+ল+3T`:
```
¦<RT¦

I'll use the digit order as the number with word syntax, so it is easier to track

98765.3210

Separate the digits into batches of 3 starting from the lowest index to the highest - (the ripple)
The decimal point is treated as its own digit (if there is one)

9 876 5.3 210

Separate the batches into 2 regions

If the echo type is positive, every other batch from the furthest to the right gets pushed down
If the echo type is negative, every other batch from the furthest to the left gets pushed down

Then the two rows are grouped to its contents

95.3
876210

If the ripple's value is greater than 0, reverse the order of digits of the lower row
If the ripple's value is less than 0, reverse the order of digits of the upper row

95.3
012678

Attach / concatenate the top row to the bottom with `জ` in the middle, to signify where the ripple originates from

<R+ল+3T 95.3জ012678 = <R+ল+3T 9, 5, ., 3, জ, 0, 1, 2, 6, 7, 8 = 98765.3210


```


Originally, this was meant to easily calculate depolarised numbers mentally, and I used a ripple of +1 or -1, but I figured that it would well in cryptography if there could be other parameters.
