# Polynomials in basal

A polynomial can be written normally, or to save space, be written as a number in array syntax, just put the veriable in curly braces. Example :
```
10x^3 - 26x^2 + 3x + 9.8x^-3 = <{x}T 10, -26, 3, 0., 0, 0, 9.8
```

You can also have a dual expansion, the two bases being interchangable - but not their directions, as it indicates which way to expand. Example : 
```
<2xT 1, 5, 10, 10, 5, 1 T11y> = T11y> 1, 5, 10, 10, 5, 1 <2xT
```

If you want to not include a few indexes, but need it for the reverse base, leave zeros:
```
<2xT 0, 0, 0, 0, 5, 1 T11y> = 14610xy^4 + 161051y^5
```