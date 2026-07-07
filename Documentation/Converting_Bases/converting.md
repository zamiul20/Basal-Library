# Coverting a base to another base

There are 2 ways of converting bases
1. Converting to another base
2. Converting to another base from a defined base

For converting bases, the symbol to use as an operator is `র`

First Method : Converting an arbitary base to another, by using the input number's base 
Second Method : Converting an arbitary base to another, by using a given base (has to be discrete), converting the input number as if it were that

Note : the first method cannot change a number's value, only how it is represented; the second method can change the value of the number

Example:
```
¦<16T¦

  র  10, 2, 14 = 101000101110 = <10T 2606
 <2T

  র <10T 2606 = 101000101110 = <10T 2606
 <2T

 <16গT
  র  <10গT 10, 2, 14 = 101000101110 = <10T 2606
 <2T

 <10গT
  র  10, 2, 14 = 10000001010 = <10T 1034
 <2T
```

Inputs and their meanings:
```
Convert the number of [q] from the base of [q] to the base [o]:
 
  র  q
  o

Convert the number of [q] from the base of [u] to the base [o]:

  u
  র  q
  o
```