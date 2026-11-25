# Zaming

Having this file open with one of the Zaming code files may help with understanding

This is a function that uses two bases to transform the value of a number - convert and cast

How it works:

1. Convert the number to the [convert] base
2. Deconvert the converted number from the [cast] base

For the second step, you have to deconvert the number **as if** it had the base of [cast], not [convert]

`sequencial.py` performs the function on a range of values, whereas `iterative.py` cycles the same value with the zaming function.

