# Systematic Function Expansions

You can create indexes with a desired function, with the `এ` character as an operator, the number's base being the plane's base (<10T if undefined).

Example of making a number with every index as a term of a floor of Pascal's triangle, from 2nd term to the 6th (step of 1); the final number is 77,156 because the default base is denary :
```
 j=1
  এ 1 ¦10Cj¦ = 6, 15, 20, 15, 6 = 77156
  5
```
Think of it as a for-loop that includes both inputs and everything in between, by incrementing the variable's first value with the number on the right of the `এ`.

All inputs and their meanings:
```
 z=s
  এ i ¦Ffunction(i)¦
  e

is equal to (in programming languages) :
(C++ || C# || C) : for (float z = [s]; z <= [e]; z += [i]) {// Add value of Ffunction(i) to the number}
(Rust) : let mut z = [s]; loop{/* Add value of Ffunction(i) to the number*/ if(z==e){break;}z+=[i];}
```
