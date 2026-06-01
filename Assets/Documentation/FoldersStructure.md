\# Estructura de Carpetas Recomendada para Proyectos Unity



\## Objetivo



Mantener una organización clara, escalable y fácil de mantener para proyectos Unity de cualquier tamaño, evitando la mezcla de recursos, código y herramientas externas.



\---



\# Estructura General



```text

Assets/

│

├── \_Project/

│   ├── Art/

│   │   ├── Characters/

│   │   ├── Environment/

│   │   ├── Props/

│   │   ├── Materials/

│   │   ├── Textures/

│   │   ├── VFX/

│   │   └── UI/

│   │

│   ├── Audio/

│   │   ├── Music/

│   │   ├── SFX/

│   │   ├── Voices/

│   │   └── Mixers/

│   │

│   ├── Code/

│   │   ├── Core/

│   │   ├── Gameplay/

│   │   ├── UI/

│   │   ├── Systems/

│   │   ├── Managers/

│   │   ├── ScriptableObjects/

│   │   └── Editor/

│   │

│   ├── Prefabs/

│   │   ├── Characters/

│   │   ├── Environment/

│   │   ├── Gameplay/

│   │   └── UI/

│   │

│   ├── Scenes/

│   │   ├── Bootstrap/

│   │   ├── Menus/

│   │   ├── Levels/

│   │   └── Testing/

│   │

│   ├── Animations/

│   │   ├── Characters/

│   │   ├── UI/

│   │   └── Controllers/

│   │

│   ├── Resources/

│   ├── Addressables/

│   ├── Settings/

│   └── Documentation/

│

├── Plugins/

├── ThirdParty/

├── Gizmos/

├── StreamingAssets/

└── Tests/

```



\---



\# Descripción de Carpetas



\## \_Project



Contiene todos los recursos propios del juego.



Se recomienda utilizar el prefijo `\_` para que aparezca al inicio del explorador de Unity.



\---



\## Art



Recursos visuales.



\### Characters



\* Modelos de personajes

\* Sprites

\* Rigging

\* Meshes



\### Environment



\* Terrenos

\* Edificios

\* Vegetación

\* Escenarios



\### Props



\* Objetos interactivos

\* Decoración

\* Armas

\* Coleccionables



\### Materials



\* Materiales de Unity

\* Materiales de shaders

\* Materiales de VFX



\### Textures



\* Albedo

\* Normal Maps

\* Masks

\* Spritesheets



\### VFX



\* Partículas

\* Efectos visuales

\* Shaders especiales



\### UI



\* Iconos

\* Botones

\* Fondos

\* Sprites de interfaz



\---



\## Audio



\### Music



Música de fondo.



\### SFX



Efectos de sonido.



Ejemplos:



\* Disparos

\* Pasos

\* Impactos

\* Explosiones



\### Voices



\* Narraciones

\* Diálogos

\* Voces de personajes



\### Mixers



Audio Mixers de Unity.



\---



\## Code



Toda la lógica del proyecto.



\---



\### Core



Código base reutilizable.



```text

Core/

├── Interfaces/

├── Extensions/

├── Utilities/

├── Events/

└── Constants/

```



Ejemplos:



\* Event Bus

\* Helpers

\* Utilidades matemáticas

\* Interfaces compartidas



\---



\### Gameplay



Mecánicas del juego.



```text

Gameplay/

├── Player/

├── Enemies/

├── Combat/

├── Inventory/

├── Quests/

└── Skills/

```



\---



\### UI



Controladores de interfaz.



Ejemplos:



\* MainMenuController

\* HUDController

\* InventoryUI



\---



\### Systems



Sistemas globales.



Ejemplos:



\* Save System

\* Dialogue System

\* Economy System

\* Achievement System



\---



\### Managers



Coordinadores globales.



Ejemplos:



```text

GameManager

AudioManager

UIManager

SaveManager

```



\---



\### ScriptableObjects



Datos configurables.



Ejemplos:



```text

WeaponData

EnemyData

ItemData

QuestData

CharacterData

```



\---



\### Editor



Herramientas exclusivas para el Editor de Unity.



Ejemplos:



\* Custom Inspectors

\* Ventanas personalizadas

\* Generadores automáticos



\---



\## Prefabs



Objetos reutilizables.



```text

Prefabs/

├── Characters/

├── Enemies/

├── Weapons/

├── Environment/

└── UI/

```



\---



\## Scenes



\### Bootstrap



Escena inicial.



Responsabilidades:



\* Inicialización de sistemas

\* Carga de servicios

\* Configuración global



\---



\### Menus



Escenas de interfaz.



Ejemplos:



\* Main Menu

\* Settings

\* Credits



\---



\### Levels



Escenas jugables.



Ejemplo:



```text

Level\_01

Level\_02

Level\_03

Boss\_01

```



\---



\### Testing



Escenas temporales para desarrollo.



No deben formar parte del Build final.



\---



\## Animations



\### Characters



Animaciones de personajes.



\### UI



Animaciones de interfaz.



\### Controllers



Animator Controllers.



\---



\## Resources



Contiene assets cargados mediante:



```csharp

Resources.Load<T>()

```



Mantener esta carpeta pequeña para evitar aumentar innecesariamente el tamaño del build.



\---



\## Addressables



Assets gestionados mediante Addressables.



Ideal para:



\* DLC

\* Descargas remotas

\* Contenido modular

\* Assets grandes



\---



\## Settings



Configuraciones globales.



Ejemplos:



\* Input Actions

\* Render Pipeline Assets

\* Configuración de cámaras

\* Configuración global del juego



\---



\## Documentation



Documentación técnica.



Ejemplos:



```text

Architecture.md

GameDesign.md

ArtGuide.md

CodingStandards.md

```



\---



\## Plugins



SDKs o librerías que Unity requiere en ubicaciones específicas.



Ejemplos:



\* Android SDK Extensions

\* iOS Plugins

\* SDKs nativos



\---



\## ThirdParty



Assets externos.



Ejemplos:



```text

DOTween/

Odin/

FMOD/

TextMeshProExtensions/

```



Nunca modificar directamente estos recursos.



\---



\## Gizmos



Imágenes utilizadas por Gizmos personalizados en el Editor.



\---



\## StreamingAssets



Archivos copiados sin modificación al build.



Ejemplos:



\* JSON

\* CSV

\* Videos

\* Bases de datos



\---



\## Tests



Pruebas automatizadas.



```text

Tests/

├── EditMode/

└── PlayMode/

```



\---



\# Organización Recomendada para Proyectos Grandes



Cuando el proyecto crezca, organizar por funcionalidades en lugar de por tipo.



Ejemplo:



```text

Gameplay/

├── Inventory/

│   ├── InventorySystem.cs

│   ├── InventoryUI.cs

│   ├── InventoryData.cs

│   └── InventoryTests.cs

│

├── Combat/

│   ├── CombatSystem.cs

│   ├── DamageCalculator.cs

│   ├── WeaponData.cs

│   └── CombatUI.cs

│

└── Quests/

&#x20;   ├── QuestSystem.cs

&#x20;   ├── QuestData.cs

&#x20;   └── QuestUI.cs

```



Ventajas:



\* Mejor escalabilidad.

\* Menor acoplamiento.

\* Más fácil encontrar archivos relacionados.

\* Facilita el trabajo en equipo.



\---



\# Convenciones de Nombres



\## Carpetas



```text

PascalCase

```



Ejemplos:



```text

Player

Inventory

Combat

ScriptableObjects

```



\---



\## Scripts



```text

PlayerController.cs

EnemyAI.cs

InventorySystem.cs

```



\---



\## Prefabs



```text

Player.prefab

EnemyGoblin.prefab

HealthPotion.prefab

```



\---



\## ScriptableObjects



```text

SO\_WeaponData

SO\_ItemData

SO\_EnemyData

```



\---



\# Regla General



Todo lo que sea propio del juego debe vivir dentro de:



```text

Assets/\_Project

```



Todo lo que provenga de terceros debe vivir dentro de:



```text

Assets/ThirdParty

```



Esto facilita actualizaciones, mantenimiento y migraciones entre proyectos.



