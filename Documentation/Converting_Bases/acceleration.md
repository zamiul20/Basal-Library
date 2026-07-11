# Changing the Velocity of a number

The velocity is the increment of a number's index, which is normally 1.
The velocity can be any number

Example of using a base with the velocity when it is not one:
```
The root of 2:

2 ^ 0.5 = 1.41421356237 = <2 স 0.5T 10 = <2T 1.01101010000010011110011

2 plus the root of 2:

2 + 2 ^ 0.5 = 3.41421356237 = <2 স 0.5T 110 = <2T 11.01101010000010011110011
```

Changing a number's base's velocity:

If the current velocity [c] and the target velocity [b] satisfy the equation (⌊c / b⌋ = c / b), then both methods listed below can work, otherwise, only the second method will work

First Method : Distribution - add placeholders in the number
Second Method : Recalculation - calculate the value of the number and then transfer it to the base with the different velocity (method of the code files)

First Method, Example: `<10T to <10 স 0.25T`:
```
Because a regular velocity is 1 and the target velocity is 0.25, the velocities satisfy the equation of (⌊1 / 0.25⌋ = 1 / 0.25), the first method can be used.

78652926.256

Separate all digits (decimal point is stuck to digit with index of 0) and put it in a row, and add ((c / b) - 1) placeholders - 3 placeholders

7 8 6 5 2 9 2 6. 2 5 6 -> 7 000 8 000 6 000 5 000 2 000 9 000 2 000 6. 000 2 000 5 000 6

Bring everything together

<10 স 0.25T 70008000600020006.000200050006 = 78652926.256
```

Second Method, Example: `<10T to <10 স 0.255T`:
```
78652926.256

calulate how many digits you will need in the integer side to accommodate the number with the equation:
(1 + ⌊log(|num|, (base ** velocity))⌋) - mathematical notation
OR 
(1 + (log(abs(num), (bass ** velocity)) // 1)) - programming notation (Python)
(1 + floor(log(abs(num), pow(bass, velocity)))) - programming notation (C++)

31 digits

for every digit [d], the index is (d * velocity), 
if the equation (number_value ≥ index_value) is satisfied, deduct the value (index_value x ⌊(number_value / index_value)⌋) from the number and put (⌊(number_value / index_value)⌋) in the that digit
otherwise, put a 0 in that digit

I have ended up with:
1101001000100110001100001000001

This is not the final number, as there is still some left over, so we can add a decimal point and continue

1101001000100110001100001000001.100101000011000110001000000000100001100010100110001100110011001000101
After more iterations, we have ended up with the number above, which is close enough

```
