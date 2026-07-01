#include <iostream>
#include <vector>
#include <cmath>
#include <variant>
#include <hip/hip_runtime.h>
using namespace std;
using numform = float;

__global__ void polynom(const numform*num, const numform index, const numform mulpi, numform*outout, int n)
{
    int id = blockIdx.x * blockDim.x + threadIdx.x;
    if (id < n)
    {
        outout[id] += pow(num[id], index) * mulpi;
    }
}

int main() {
    vector<numform> innum = {1, 2, 3, 4};
    numform bass = 10;
    numform velocity = 1;
    
    int rang = 256;
    int offset = 0;
    numform step = 1;
    int pos = 0;
    
    int points = floor(rang / step);
    vector<numform> inar(points, 0.0f);

    for (numform z = 0; z < points; z++)
    { inar[z] = (z * step) + offset; }
    
    size_t bytes = sizeof(numform) * points;
    numform*d_inar;
    hipMalloc(&d_inar, bytes);
    hipMemcpy(d_inar, inar.data(), bytes, hipMemcpyHostToDevice);
    
    vector<numform> outout(rang, 0);
    numform*d_outout;
    hipMalloc(&d_outout, bytes);
    hipMemcpy(d_outout, outout.data(), bytes, hipMemcpyHostToDevice);
    
    int blocksiz = 256;
    int gridsiz = (rang + blocksiz - 1) / blocksiz;
    int l = innum.size();

    for (int z = l; z > 0; z--)
    {
        hipLaunchKernelGGL(polynom, dim3(gridsiz), dim3(blocksiz), 0, 0, d_inar, (velocity * ((l - z) - pos)), innum[z - 1], d_outout, rang);
    }hipDeviceSynchronize()
    hipMemcpy(outout.data(), d_outout, bytes, hipMemcpyDeviceToHost);

    for (int z = 0; z < outout.size(); z++)
    {cout<<z<<" -> "<<outout[z]<<endl;}

    
    hipFree(d_outout); hipFree(d_inar);
    return 0;
}