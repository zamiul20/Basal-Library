# Binomial Expansion via ROCm

This script uses AMD's ROCm to accelerate the calculation of calculating polynomial coordinates.

The binom.exe file works best for x64 systems using a gfx1201 GPU, compiled with the HIP SDK For Windows, supported cards listed below
1. AMD Radeon AI PRO R9700
2. AMD Radeon RX 9070
3. AMD Radeon RX 9070 GRE
4. AMD Radeon RX 9070 XT

Other GPUs that should be able to run it are from AMD's RDNA3 and RDNA2 families.


You may need to rename the file extension to a .cpp file to compile it, for hipcc it works as is