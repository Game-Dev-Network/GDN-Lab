# Contributing

Thank you for considering contributing to GDN's Code Gift! We would love it if you forked this repository, made some changes, and to submitted a pull request. However, we need to manage this project, so we have a fairly small contributing guidance.

When we say snippet, what we really mean is any useful code resource for developers. This means that you can use as many files as you need.

## Project License

We distribute anything in the Code Gift under an adapted CC0 license. To ensure safety for people that use it, we'll get you on your first pull request to sign a Contributor License Agreement. It isn't that long, but it ensures that we can continue using your contributions later on.

## Project structure

You'll notice that our directory structure is somewhat long. We use the following format to structure code snippets in here:

```
code-gift/
|-- unity/
|   |-- example-snippet-1/
|   |   |-- v1/
|   |   |   `-- README.md
|   |   |-- v2/
|   |   |   `-- README.md
|   |   `-- VERSIONS.tsv
|   |-- example-snippet-2/
|   |   |-- v1/
|   |   |   `-- README.md
|   |   `-- VERSIONS.tsv
|   `-- INDEX.tsv
|-- unreal/
|   |-- example-snippet-1/
|   |-- example-snippet-2/
|   `-- INDEX.tsv
|-- gamemaker/
|   `-- INDEX.tsv
|-- xenko/
|   `-- INDEX.tsv
`-- godot/
    `-- INDEX.tsv
```

Each engine has its own directory. Inside each directory is a summary list of all snippets in that directory in a TSV format called `INDEX.tsv`. We chose a TSV format so that it's easily searchable.

Alongside that `INDEX.tsv` file are directories for each snippet, and inside these are directories for each new major version with a descriptor file called `VERSIONS.tsv` for the major versions.

## Creating a new snippet

There's a few steps that you'll need to take:
1. Fork this repository.
2. Make a directory under your engine directory with a descriptive name of your snippet.
3. Make a directory named `v1` under your snippet directory.
4. Create your snippet in the `v1` directory.
5. Update the `INDEX.tsv` with information on your new snippet.
6. Create a `VERSIONS.tsv` file in your snippet's root directory (copy another snippet's file if you need to) and a `README.md` with more information on things like the author and how to use it.
7. Commit and create a pull request back into the `master` branch. If this is your first pull request, you'll also need to accept the CLA—you'll get instructions for this once you've created your pull request.
8. Wait for your pull request to be approved.

## Modifying a snippet

How to do this depends on if you're making breaking changes (e.g. the old snippet cannot be directly replaced with the new one without significant changes, a version of the engine is no longer supported, behaviour will be unpredictable or different, etc).

If you need to maintain two versions simultaneously that have feature parity but are for different engine versions, you should use the same version number but different suffixes (e.g. `v1A` and `v1B`).

### Non-breaking (minor) changes

1. Fork this repository.
2. Make the changes in the major version that you intend to modify.
3. If needed, update the `README.md` in the snippet directory and the `INDEX.tsv` file for the engine with the new list of authors.
4. Update `VERSIONS.tsv` with the changes.
4. Commit and create a pull request back into the `master` branch. If this is your first pull request, you'll also need to accept the CLA—you'll get instructions for this once you've created your pull request.
5. Wait for your pull request to be approved.

### Breaking (major) changes

1. Fork this repository.
2. Duplicate the major version directory that you're basing the new major version off, and increase the version number by one.
3. Make your changes in the new version directory.
4. Update `README.md` in your major version directory with your new changes and how to use the snippet.
5. Update `INDEX.tsv` for the engine if needed.
6. Update `VERSIONS.tsv` in your snippet root directory with your new major version.
7. Commit and create a pull request back into the `master` branch. If this is your first pull request, you'll also need to accept the CLA—you'll get instructions for this once you've created your pull request.
8. Wait for your pull request to be approved.

## Confused?

Head over to our Discord server and message Harry Shipton, or create a pull request with your best attempt to follow this and we'll try to fix everything up for you.

## Code of Conduct

Please see the separate [Code of Conduct](CODE_OF_CONDUCT.md).
