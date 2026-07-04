#include <iostream>
#include <vector>
#include <cmath>
#include <typeinfo>
#include <hip/hip_runtime.h>
using namespace std;
using numform = float;

__global__ void binombas(const numform firbas, const numform secbas, const numform firvel, const numform secvel, numform*outout, int n)
{
    int id = blockIdx.x * blockDim.x + threadIdx.x;
    if (id < n)
    {
        outout[id] *= pow(firbas, (id + 1) * firvel) * pow(secbas, (n - (id + 1)) * secvel);
    }
}

int main() {
    numform firbas, firvel, secbas, secvel;
    int expansion = 1024;
    cout<<"Script and kernel operates in : "<<typeid(firbas).name();
    cout<<"\nType in the first base : ";cin>>firbas;
    cout<<"\nType in the second base : ";cin>>secbas;
    cout<<"\nType in the first base's velocity : ";cin>>firvel;
    cout<<"\nType in the second base's velocity : ";cin>>secvel;
    cout<<"\nType in the floor of pascal's triangle : ";cin>>expansion;
    
    vector<numform> houtout = {1, 1};

    expansion--;
    for (int i = 0; i < expansion; i++)
    {
        vector<numform>r(houtout); houtout = {1};
        for (int z = 0; z < r.size(); z++)
        {if(z==0){continue;}
            houtout.emplace_back(r[z] + r[z - 1]);
        }houtout.emplace_back(1); 
    }

    size_t totelem = houtout.size();

    int bytes = sizeof(numform) * totelem;
    numform*doutout;
    hipMalloc(&doutout, bytes);
    hipMemcpy(doutout, houtout.data(), bytes, hipMemcpyHostToDevice);

    int blocksiz = 256;
    int gridsiz = (totelem + blocksiz - 1) / blocksiz;
    hipLaunchKernelGGL(binombas, dim3(gridsiz), dim3(blocksiz), 0, 0, firbas, secbas, firvel, secvel, doutout, totelem);
    hipDeviceSynchronize();

    hipMemcpy(houtout.data(), doutout, bytes, hipMemcpyDeviceToHost);

    numform totall = 0;
    for (int z = 0; z < totelem; z++)
    {cout<<z<<" -> "<<houtout[z]<<endl;totall+=houtout[z];}
    cout<<"\nTotal -> "<<totall;
    
    hipFree(doutout);
    return 0;
}