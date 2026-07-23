# Depolarising

This file explains how to make a number have a different polarity, and how to turn a regular number into a number of another polarity (depolarising) by hand

Polarities:
1. Regular - number structure of everyday bases of : denary, binary, hexadecimal, octal
2. Negative - where every odd positioned digit is negative
3. Double Negative - where every even positioned digit is negative

Regular to Negative - `<RT to <RঋT` 
```
If we want to depolarise the number <10T 1357, we 'channel' the digits into if they would become the opposite (in this case, positive to negative), and if they would stay the same:

The digits on the lower 'channel' will become negative, from positive, so we have to compensate, by doing some arithmetic - keep in mind the base's value is 10

Either: (If the velocity is 1, do the following) for every digit [i] in the bottom channel, replace it with [base_value - i], which is [10 - i] as the base_value is 10, then we increment the following digit by 1

3  2  1  0      4  3  2  1  0    : Positions of digits

   3     7  --> 1     4     7
1     5     -->    9     5       <10ঋT 19457 = <10T 1357

Or: (Works for any velocity, also the method of the code files) for every digit [i] in the bottom channel, add ( (base_value x 2 - 2 x digit_value) x (base_value ^ (digit_position x velocity)) ) to a new number (starting at 0), and when you have completed the whole of the bottom channel, add the new number to the original number

3  2  1  0       4   3   2   1   0    : Positions of digits

   3     7  -->      1   3   5   7
1     5     --> +1   8   1   0   0  - Column addition
                 1   9   4   5   7  -> <10ঋT 19457 = <10T 1357
```

Regular to Double Negative - `<RT to <RদT`
```
It is the same method as converting from Regular to Double Negative, but the channels are flipped from the start.

If we want to depolarise the number <10T 1357, we 'channel' the digits into if they would become the opposite (in this case, positive to negative), and if they would stay the same:

The digits on the lower 'channel' will become negative, from positive, so we have to compensate, by doing some arithmetic - keep in mind the base's value is 10

Either: (If the velocity is 1, do the following) for every digit [i] in the bottom channel, replace it with [base_value - i], which is [10 - i] as the base_value is 10, then we increment the following digit by 1

3  2  1  0       3   2   1   0    : Positions of digits

1     5     -->  2       6   
   3     7  -->      7       3    <10দT 2763 = <10T 1357
   
Or: (Works for any velocity, also the method of the code files) for every digit [i] in the bottom channel, add ( (base_value x 2 - 2 x digit_value) x (base_value ^ (digit_position x velocity)) ) to a new number (starting at 0), and when you have completed the whole of the bottom channel, add the new number to the original number

3  2  1  0       3   2   1   0    : Positions of digits

1     5     -->  1   3   5   7
   3     7  --> +1   4   0   6  - Column addition
                 2   7   6   3  -> <10দT 2763 = <10T 1357
```

NOTE: for Fractal bases (of both types), use array syntax
