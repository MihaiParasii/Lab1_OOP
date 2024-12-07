# Ecosystem Simulation Project

This project simulates an ecosystem where different types of entities (e.g., animals and plants) interact with each other. The simulation includes behaviors such as movement, eating, growth, and death. Reports are generated to summarize these processes.

---

## Table of Contents

- [Overview](#overview)
- [Features](#features)
- [Project Structure](#project-structure)
- [Classes and Interfaces](#classes-and-interfaces)
  - [Key Classes](#key-classes)
  - [Interfaces](#interfaces)
- [Usage](#usage)
- [Example Report](#example-report)
- [Contributing](#contributing)
- [License](#license)

---

## Overview

This project models an ecosystem consisting of plants and animals (herbivores, omnivores, etc.). Each entity in the simulation has specific behaviors and attributes. The primary goal is to track the interactions within the ecosystem, such as which entities grow, die, or are consumed by others.

The simulation generates a detailed report that includes information about:
- Eating processes.
- Dying processes.
- Growth processes.

---

## Features

- **Dynamic Map**: A grid-based map that tracks the positions of entities.
- **Ecosystem Entities**: Includes plants and animals with distinct characteristics and behaviors.
- **Movement**: Animals can move in all four cardinal directions.
- **Reports**: A detailed report builder tracks ecosystem events.
- **Extendability**: Easy to add new types of entities or behaviors.

---

Lab4/ <br>
├── EcosystemEntity.cs       # Base class for all entities <br>
├── Animal.cs                # Base class for all animals <br>
├── HerbivoreAnimal.cs       # Herbivore animal implementation <br>
├── OmnivoreAnimal.cs        # Omnivore animal implementation <br>
├── Plant.cs                 # Plant implementation <br>
├── Map.cs                   # Represents the simulation map <br>
├── Position.cs              # Struct for entity positioning <br>
├── Report.cs                # Generates detailed simulation reports <br>
├── ReportBuilder.cs         # Implements the report-building logic <br>
├── IReportBuilder.cs        # Interface for building reports <br>
├── IMovable.cs              # Interface for movable entities <br>
└── Program.cs               # Entry point for the simulation <br>



---

## Classes and Interfaces

### Key Classes

#### **EcosystemEntity**
- Represents a general entity in the ecosystem.
- Attributes:
  - `Name`: The name of the entity.
  - `Position`: The entity's current position.
  - `Energy`: Energy level of the entity.
  - `SurviveRate`: The survival probability of the entity.
  - `Symbol`: The symbol representing the entity on the map.
- Methods:
  - `GrowEntity()`: Increases the entity's energy.
  - `IsDie()`: Determines if the entity is dead.

#### **Animal**
- Base class for all animals.
- Inherits from `EcosystemEntity`.
- Attributes:
  - `Speed`: The movement speed of the animal.
- Methods:
  - `CanEat(EcosystemEntity entity)`: Determines if the animal can eat a specific entity.

#### **HerbivoreAnimal**
- Inherits from `Animal`.
- Only eats plants.

#### **OmnivoreAnimal**
- Inherits from `Animal`.
- Eats both plants and animals.

#### **Plant**
- Inherits from `EcosystemEntity`.
- Gains energy through growth.

#### **Map**
- Manages the grid-based map of the ecosystem.
- Tracks entity positions.
- Methods:
  - `ClearMap()`: Resets the map.
  - `SetEntityOnMap(EcosystemEntity entity)`: Places an entity on the map.

#### **Report**
- Tracks and stores details of ecosystem processes (eating, dying, and growing).
- Methods:
  - `ToString()`: Returns a detailed string representation of the report.

#### **ReportBuilder**
- Implements `IReportBuilder`.
- Builds reports by adding details of processes (eating, dying, growing).

---

### Interfaces

#### **IReportBuilder**
- Provides methods to build ecosystem reports.
  - `GetReport()`: Retrieves the current report.
  - `AddEatProcess(Animal hunter, EcosystemEntity prey)`: Adds an eating event.
  - `AddDyingProcess(EcosystemEntity entity)`: Adds a dying event.
  - `AddGrowProcess(EcosystemEntity entity)`: Adds a growth event.

#### **IMovable**
- Defines movement behavior for movable entities.
  - `MoveLeft()`
  - `MoveRight()`
  - `MoveUp()`
  - `MoveDown()`

---
