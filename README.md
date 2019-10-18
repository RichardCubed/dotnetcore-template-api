# dotnetcore_template_api

A nice clean .NET Core API template with all the good bits included.  I use this as a base for new C# .NET CORE microservices.

The project was built using VisualStudio (Xamarin) for OSX, but the same project should work fine with Windows and VisualStudio.  You can always build from the command line as well if VSCode is your IDE of choice.

## Included in the Project

Middleware for handling common exceptions<br/>
DynamoDB models and CRUD operations<br/>
A Mediator pattern for clean seperation of responsibilities<br/>
AWS Ray for distributed tracing<br/>
A DockerFile for building and deploying<br/>
Unit testing framework<br/>
Healthcheck endpoint<br/>
Environment specific configurations<br/>
Basic HTTP header based security<br/>

## Running the Project Locally

If you want to run the project "as is" you'll need to configure a few things locally and a few in AWS.  You'll need an AWS account, the AWS CLI installed and configured as well as a sample DynamoDB table.

The project is currently configured to use AWS region us-east-1.

## License
[MIT](https://choosealicense.com/licenses/mit/)