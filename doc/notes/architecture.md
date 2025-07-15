Screaming Architecture e Package by Feature são conceitos relacionados na arquitetura de software que promovem uma organização do código que prioriza a compreensão do domínio de negócio da aplicação. Embora complementares, eles possuem ênfases ligeiramente diferentes:

Screaming Architecture (Arquitetura que Grita):

Conceito principal: O termo, cunhado por Robert C. Martin (Uncle Bob), sugere que a estrutura da sua aplicação (especialmente a estrutura de diretórios e pacotes de alto nível) deve "gritar" ou comunicar imediatamente o que o sistema faz do ponto de vista do negócio, e não as tecnologias que ele usa.

Foco: O foco principal é a intenção de negócio e os casos de uso. Ao olhar a estrutura do projeto, deve ser evidente que se trata de um sistema de "gerenciamento de inventário" ou "processamento de pedidos", em vez de "aplicativo Spring Boot" ou "aplicativo Angular".

Analogia: Uncle Bob usa a analogia de um projeto arquitetônico de um prédio. Ao ver a planta, você deve ser capaz de dizer se é uma escola, uma biblioteca ou um hospital, e não apenas que é feito de concreto ou aço.

Implementação: Isso geralmente se traduz em organizar o código em torno de domínios ou casos de uso específicos, com pastas como pedidos, clientes, pagamentos, e dentro dessas pastas, você pode encontrar os detalhes técnicos (controladores, serviços, repositórios) relacionados a essa funcionalidade.

Benefícios:

Clareza do negócio: Facilita a compreensão do propósito do sistema para novos desenvolvedores e stakeholders.

Manutenibilidade: Torna mais fácil localizar e modificar o código relacionado a uma funcionalidade específica.

Separação de preocupações: Incentiva a manter a lógica de negócio centralizada e independente de detalhes técnicos.

Menos acoplamento: Reduz a dependência entre módulos não relacionados.

Package by Feature (Empacotamento por Funcionalidade):

Conceito principal: É uma abordagem de organização de código onde todas as classes e arquivos relacionados a uma funcionalidade específica são agrupados no mesmo pacote (ou diretório/módulo).

Foco: O foco é na coesão e modularidade em torno de uma funcionalidade completa. Em vez de agrupar por camadas técnicas (e.g., controllers, services, repositories), você agrupa por "características" ou "recursos" do sistema.


Exemplo: Em vez de ter:

/controllers
    OrderController.java
    ProductController.java
/services
    OrderService.java
    ProductService.java
/repositories
    OrderRepository.java
    ProductRepository.java
Você teria:

/order
    OrderController.java
    OrderService.java
    OrderRepository.java
    Order.java
/product
    ProductController.java
    ProductService.java
    ProductRepository.java
    Product.java
Benefícios:

Alta coesão: Tudo o que pertence a uma funcionalidade está junto, o que facilita o trabalho nela.

Baixo acoplamento: As dependências entre diferentes funcionalidades são minimizadas.

Facilidade de exclusão: Em muitos casos, se uma funcionalidade for descontinuada, basta apagar o diretório correspondente.

Melhora a navegação: Os desenvolvedores gastam menos tempo procurando arquivos relacionados a uma funcionalidade.

Clareza do sistema: Ajuda a entender rapidamente as principais funcionalidades ao olhar a estrutura de pacotes.

Qual é a diferença?

A principal diferença é que Package by Feature é uma técnica de implementação que ajuda a alcançar os objetivos da Screaming Architecture.

A Screaming Architecture é uma filosofia ou princípio que diz que sua arquitetura deve comunicar o domínio do negócio.

Package by Feature é uma prática ou estilo de organização de código que se alinha perfeitamente com a Screaming Architecture, permitindo que a estrutura do seu projeto "grite" as funcionalidades de negócio.

Em outras palavras, se você implementar o Package by Feature, seu sistema naturalmente terá uma Screaming Architecture, pois as funcionalidades de negócio serão os elementos de destaque na estrutura do seu código. A Screaming Architecture é o "porquê" (focar no negócio), e o Package by Feature é o "como" (organizar o código por funcionalidade para refletir o negócio).

---
# Referências

https://blog.cleancoder.com/uncle-bob/2011/09/30/Screaming-Architecture.html#:~:text=A%20good%20architecture%20emphasizes%20the,decouples%20them%20from%20peripheral%20concerns.
https://www.milanjovanovic.tech/blog/screaming-architecture
https://www.nilebits.com/blog/2024/09/what-is-screaming-architecture/
https://medium.com/@hrynkevych/screaming-architecture-in-front-end-de72d9ec961c