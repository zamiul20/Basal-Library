# Using the ROCm HIP files

These files contain C++ code, but end with `.hip`, and are compiled with the hipcc compiler (requires MSVC / Clang)

The HIP files are for specialised functions that can - and benefit greatly from - GPU acceleration, works best on Linux (Ubuntu and Mint)

HIP files can be compiled for ROCm-capable targets, others may work with workarounds:

Ryzen:
Ryzen AI Max 300 Series (gfx1151)
Ryzen AI 300 & 400 Series (gfx1150)

Radeon:

RDNA4 : RX 9000 Series (gfx1201)

RDNA3 : RX 7000 Series (gfx 1100 / 1101 / 1102 / 1103)

RDNA2 : RX 6000 Series (gfx 1030)

RDNA1 : RX 5000 Series (gfx 1010 / 1012)

Vega : 56, 64, Radeon Instinct MI25, Radeon VII (gfx 900 / 906)

Radeon PRO:

RDNA4 : Radeon AI PRO R9700

RDNA3 : Radeon Pro W7900, W7900 Dual Slot, W7800, W7700, and V710

RDNA2 : Radeon Pro W6800 and V620
