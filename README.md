# SearchFight :airplane:

Simple Console App that queries search engines and compares how many results they return, for Example:

```
C:\SearchFight.exe .net java
```

```
.net: Google: 13200000 MSN Search: 15600000
java: Google: 405000 MSN Search: 20700000
Google winner: .net
MSN Search winner: java
Total winner: .net
```

## Deployment

Compile the solution with visual studio and the exe will be generated.

## Built With

* [Fody](https://github.com/Fody/Costura) - Embeds dependencies as resources.
* [Fluent Assertions](https://github.com/fluentassertions/fluentassertions) - To Improve readability of the tests

## License

This project is licensed under the MIT License
