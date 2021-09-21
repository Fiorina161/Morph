# Morph

This little utility reads a file and replaces variable placeholders
with their environment values. The result is sent to standard output.
I use it to modify configuration files when switching development
environment, but it can be used on any text file, for any purpose.

## Usage example

    morph config.var > config.ini

## Sample file 

*config.var*:

    [network]
    host={{HOST}}
    port={{PORT}}

## Batch file example

*Production.cmd*

```bat
    @echo off
    
    set HOST=10.10.10.5
    set PORT=5699
    
    morph config.var > config.ini
```

## Default values

You can provide a default value to be used in case the environment
variable for a placeholder is not found. For example, in the previous
example, the *port* placeholder in *config.var* could have been
specified as `{{PORT|6000}}` and the variable could have been ommited 
in the batch file.
