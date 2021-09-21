# Morph

This little utility reads a file and replaces variable placeholders
with their environment values. The result is sent to standard output.
I use it to modify configuration files when switching development
environment, but it can be used on any text file, for any purpose.

## Usage example

```bat
    morph config.var > config.ini
```

## Sample file 

*config.var*:

```ini
    [network]
    host={{HOST}}
    port={{PORT}}
```

## Batch file example

*Production.cmd*

```bat
    @echo off
    
    set HOST=10.10.10.5
    set PORT=5699
    
    morph config.var > config.ini
```

## Default values

You can provide a default value to the variable using a `|` character as in the following example:

```ini
    [network]
    host={{HOST|127.0.0.1}}
    port={{PORT|6000}}
```

If no environment variable is found for a given variable, its default value will be substituted instead.
