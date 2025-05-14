
# 📘 Documentação: `dotnet new console`

## 📌 Descrição

O comando `dotnet new console` cria um novo projeto de aplicativo de console em C# com o SDK do .NET. Esse projeto pode ser executado diretamente no terminal com `dotnet run`.

---

## 📁 Estrutura criada

Após executar o comando, será criada uma estrutura como:

```
/<pasta>
  ├── Program.cs
  └── <pasta>.csproj
```

---

## 🛠️ Sintaxe

```bash
dotnet new console [opções]
```

---

## 🔧 Opções comuns

| Opção                      | Descrição                                                            |
|----------------------------|----------------------------------------------------------------------|
| `-o`, `--output <DIR>`      | Define o diretório de saída                                          |
| `--name <NOME>`             | Define o nome do projeto e do namespace                              |
| `--no-restore`              | Não executa `dotnet restore` após criar o projeto                    |
| `--framework <TFM>`         | Define o framework-alvo (ex: `net8.0`, `net6.0`)                     |
| `--use-program-main`        | Usa `static void Main()` clássico (sem top-level statements)          |
| `--langVersion <VERSAO>`    | Define a versão da linguagem C# (ex: `12`, `preview`)                |
| `-f`, `--force`             | Força a criação do projeto mesmo em pasta não vazia                  |

---

## 🧪 Exemplos práticos

### 1. Criar um projeto simples:

```bash
dotnet new console
```

### 2. Criar projeto em uma pasta específica:

```bash
dotnet new console -o src
```

### 3. Definir nome do projeto:

```bash
dotnet new console --name Aspa -o src
```

### 4. Usar `Main` tradicional (sem top-level statements):

```bash
dotnet new console --use-program-main
```

### 5. Criar projeto sem restaurar pacotes:

```bash
dotnet new console --no-restore
```

### 6. Criar projeto para .NET 8:

```bash
dotnet new console --framework net8.0
```

---

## 📦 Executar o projeto

Após criado:

```bash
cd <pasta>
dotnet run
```

---

## 🧰 Dica: Ver todos os templates

```bash
dotnet new list
```

---

## 📚 Referência oficial
🔗 [dotnet new <TEMPLATE>](https://learn.microsoft.com/dotnet/core/tools/dotnet-new)
