# Scouting App

An iOS and Android mobile app for scouting other teams during robotics competitions.
- track scores
- track capabilities of teams, including our own
- evaluate prospects

## Who is this app for?

The Quarks Robotics Team

## Goals

To make the process easier, efficient, convenient, and quicker.

## User Stories

User stories describe tasks and outcomes by which we will judge the completeness of the application.

- [ ] As a user I can add/edit/delete a team.
- [ ] As a user I can add/edit/delete an event.
- [ ] As a user I can score a team's performance at an event.
- [ ] As a user I can view a report of team rankings by event.
- [ ] The app can persist data to the cloud.
- [ ] The app can store data on device without internet access.
- [ ] The app can syncronize data between device and cloud.
- [ ] Multiple users can use the app at the same time.
- [ ] Data updates from one devices will be available on another user's device.
- [ ] The app will run on iOS and Android.

## Data Entities

### Team

A team is any robotics team participating in an event.

Fields:
- Team Name
- Team #

### Event

An event is any robotics meet or scrimmage where teams compete.

Fields:
- Event Name
- Event Date
- Team's Participating
- Location

### Team Event Performance

A performance is a scoring of a team's qualities or performance in an event.

Fields:
- Auto
- TeleOp
- Endgame
- Team
