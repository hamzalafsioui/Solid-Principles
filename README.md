The SOLID principles are five important rules in object-oriented programming. These help us design better, more maintainable code.

### 1. **Single Responsibility Principle (SRP)**
**Rule:** A class should have only one reason to change, meaning it should do just one thing.
**Simple Example:** If a class is responsible for managing employees, it shouldn't also be responsible for saving data to a file. Each class should focus on one task.

### 2. **Open/Closed Principle (OCP)**
**Rule:** Classes should be open for extension but closed for modification.
**Simple Example:** You should be able to add new features without changing the existing code. For instance, if you have a class that calculates salaries, you can add new types of salary calculations without touching the original code.

### 3. **Liskov Substitution Principle (LSP)**
**Rule:** Objects of a subclass should be replaceable with objects of the superclass without breaking the code.
**Simple Example:** If you have a base class `Bird`, and subclasses `Eagle` and `Penguin`, you should be able to use `Eagle` or `Penguin` wherever you use `Bird` without causing problems.

### 4. **Interface Segregation Principle (ISP)**
**Rule:** Don’t force a class to implement methods it doesn’t use. Split large interfaces into smaller ones.
**Simple Example:** If an interface has too many methods, a class implementing that interface should not be forced to use all of them. It's better to create smaller interfaces with related methods.

### 5. **Dependency Inversion Principle (DIP)**
**Rule:** High-level classes should not depend on low-level classes. Both should depend on abstractions (like interfaces).
**Simple Example:** If a class depends on another class to do its job, it should depend on an interface or abstract class, not on a concrete class. This makes the code more flexible and easier to test.

If you'd like to get in touch, feel free to contact me at **hamzalafsioui@gmail.com**.
