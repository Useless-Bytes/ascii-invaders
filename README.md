# ASCII Invaders

By André Luiz de Oliveira Vasconcelos  
alovasconcelos@gmail.com  
https://alovasconcelos.github.io/

Small console Space Invaders-style game written in C#. It renders the battlefield in the terminal (Unicode output) and uses emoji sprites for the cannon, enemies, and bullets.

Video: https://www.youtube.com/watch?v=sLe-6K28DeY

## Requirements

- Windows (sound uses `System.Media.SoundPlayer`)
- .NET SDK (project targets `netcoreapp3.1`, which is out of support and may show warnings on newer SDKs)

NuGet dependency `System.Windows.Extensions` is already referenced by the project and will be restored automatically.

## Build and Run

From the repository root:

```bash
dotnet restore
dotnet run --project .\ASCII_Invaders.csproj
```

To build only:

```bash
dotnet build .\ASCII_Invaders.csproj -c Release
```

## Controls

- Left / Right arrows: Move
- Space: Shoot
- M: Toggle sound on/off
- P: Pause
- Esc: Exit (with confirmation)

## Gameplay Notes

- Best score is persisted to `score.dat` in the current working directory.
- Levels go from 1 to 9; reaching level 9 shows the congratulations screen and restarts.

