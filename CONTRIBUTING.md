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

Alongside that `INDEX.tsv` file are directorys for each snippet, and inside these are directorys for each new major version with a descriptor file called `VERSIONS.tsv` for the major versions.

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

### Our Pledge

In the interest of fostering an open and welcoming environment, we as contributors and maintainers pledge to making participation in our project and our community a harassment-free experience for everyone, regardless of age, body size, disability, ethnicity, gender identity and expression, level of experience, nationality, personal appearance, race, religion, or sexual identity and orientation.

### Our Standards

Examples of behaviour that contributes to creating a positive environment include:
* Using welcoming and inclusive language
* Being respectful of differing viewpoints and experiences
* Gracefully accepting constructive criticism
* Focusing on what is best for the community
* Showing empathy towards other community members

Examples of unacceptable behaviour by participants include:
* The use of sexualized language or imagery and unwelcome sexual attention or advances
* Trolling, insulting/derogatory comments, and personal or political attacks
* Public or private harassment
* Publishing others' private information, such as a physical or electronic address, without explicit permission
* Other conduct which could reasonably be considered inappropriate in a professional setting

### Our Responsibilities

GDN moderators (the project maintainers) are responsible for clarifying the standards of acceptable behaviour and are expected to take appropriate and fair corrective action in response to any instances of unacceptable behaviour.

Project maintainers have the right and responsibility to remove, edit, or reject comments, commits, code, wiki edits, issues, and other contributions that are not aligned to this Code of Conduct, or to ban temporarily or permanently any contributor for other behaviours that they deem inappropriate, threatening, offensive, or harmful.

### Scope

This Code of Conduct applies both within project spaces and in public spaces when an individual is representing the project or its community. Examples of representing a project or community include using an official project e-mail address, posting via an official social media account, or acting as an appointed representative at an online or offline event. Representation of a project may be further defined and clarified by project maintainers.

### Enforcement

Instances of abusive, harassing, or otherwise unacceptable behaviour may be reported by contacting the project team on one of the email addresses listed in the Discord server Code of Conduct. All complaints will be reviewed and investigated and will result in a response that is deemed necessary and appropriate to the circumstances. The project team is obligated to maintain confidentiality with regard to the reporter of an incident. Further details of specific enforcement policies may be posted separately.

Project maintainers who do not follow or enforce the Code of Conduct in good faith may face temporary or permanent repercussions as determined by other members of the project's leadership.

### Discord Code of Conduct

The Code of Conduct present on our Discord server also applies to this project. You can find the latest version of that [here][Discord Code of Conduct].

### Attribution

This Code of Conduct is adapted from the [Contributor Covenant][homepage], version 1.4, available at [http://contributor-covenant.org/version/1/4][version]

[homepage]: http://contributor-covenant.org
[version]: http://contributor-covenant.org/version/1/4/
[Discord Code of Conduct]: https://drive.google.com/file/d/0B_1-SSt4d0_JT3F6LUxwZ1NELWM/view
