# Morph

This little utility reads a file and replaces variable placeholders
with their environment values. The result is sent to standard output.
I use it to modify configuration files when switching development
environment, but it can be used on any text file, for any purpose.

### Usage example

    morph config.var > config.ini

### Sample file 

*config.var*:

-------------
    [network]
    host={{F1_REMOTE_HOST}}
    port={{F1_REMOTE_PORT}}

### Batch file example

*Production.cmd*

    @echo off
    set F1_REMOTE_HOST=10.10.10.5
    set F1_REMOTE_PORT=5699
    morph config.var > config.ini

*Testing.cmd*

    @echo off
    set F1_REMOTE_HOST=10.10.10.12
    set F1_REMOTE_PORT=5699
    morph config.var > config.ini

### Default values

You can provide a default value to be used in case the environment
variable for a placeholder is not found. For example, in the previous
example, the *port* placeholder in *config.var* could have been
specified as `{{F1_REMOTE_PORT|5699}}` and the port variable could
have been ommited in the batch files:

Production.cmd

    @echo off
    set F1_REMOTE_HOST=10.10.10.5
    morph config.var > config.ini
