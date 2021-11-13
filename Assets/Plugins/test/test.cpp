extern "C" {
int _asmAdd(int x, int y)
{
    int sum=2;
//     _asm
//     {
//         mov eax, x;
//         mov ebx, y;
//         add eax, ebx;
//         mov sum, eax;
//     }

    return sum;
}

}