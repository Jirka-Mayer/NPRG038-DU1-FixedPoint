.NET I - homework 1, 2
======================

Repo: [https://github.com/Jirka-Mayer/NPRG038-DU1-FixedPoint](https://github.com/Jirka-Mayer/NPRG038-DU1-FixedPoint)

Task: [https://d3s.mff.cuni.cz/~pacovsky/dotnet](https://d3s.mff.cuni.cz/~pacovsky/dotnet)

## Benchmark summary

    BenchmarkDotNet=v0.11.4, OS=ubuntu 18.04
    Intel Core i5-7200U CPU 2.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
        [Host]     : Mono 5.16.0.179 (tarball Thu), 64bit 
        DefaultJob : Mono 5.16.0.179 (tarball Thu), 64bit 


|           Method |              Mean |          Error |         StdDev |
|----------------- |------------------:|---------------:|---------------:|
| Elimination16_16 | 13,145,786.663 ns | 41,837.4952 ns | 37,087.8497 ns |
|  Elimination24_8 | 13,095,395.837 ns | 28,581.4271 ns | 25,336.6907 ns |
|      IntToQ16_16 |          4.842 ns |      0.0122 ns |      0.0102 ns |
|       IntToQ24_8 |          4.841 ns |      0.0090 ns |      0.0084 ns |

První benchmark dělá gaussovu eliminaci na matici `100x100` ve dvou typech `16_16` a `24_8`. Druhý benchmark měří převádění z intu na typ `Fixed`.

Zdá se, že rychlost eliminace prakticky nezávisí na typu. Střední hodnota je skoro stejná. Jediné, co závisí na pozici desetinné čárky je shiftování při násobení, ale zdá se, že shift je stejně rychlý bez ohledu na to o kolik se shiftuje. Nebo je ten rozdíl v rychlosti dost zanedbatelný.
