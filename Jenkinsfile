pipeline {
    
    agent any

    parameters {
        string (name : 'SolutionName', defaultValue: 'webapi.sln',description: '')
        string (name : 'LocalImage', defaultValue: 'aspnetapp',description: '')
        string (name : 'RemoteImage', defaultValue: 'webapi',description: '')
        string (name : 'Username', defaultValue: 'vitripathi',description: '')
        string (name : 'ContainerName', defaultValue: 'webapicontainer',description: '')
    }
    
    stages {
        stage('build') {
            steps {
               bat 'dotnet build %SolutionName% -p:Configuration=release -v:q'
            }
        }

        stage('sonarqube analysis'){
            steps {
                bat 'dotnet %SONARQUBE_PATH% begin /k:"webapi" /d:sonar.host.url="http://localhost:9000" /d:sonar.login="%SONARQUBE_TOKEN%"'
               bat 'dotnet build'
                bat 'dotnet %SONARQUBE_PATH% end /d:sonar.login="%SONARQUBE_TOKEN%"'
            }
        }

         stage('publish') {
            steps {
               bat 'dotnet publish %SolutionName% -p:Configuration=release -v:q'
            }
        }
        
        stage ('BuildDockerImage')
        {
            steps {
                bat 'docker build -t %LocalImage% -f Dockerfile .'
            }
        }
        
        stage('Tag and Push image to Docker')
        {
            steps{
                  script{
                    docker.withRegistry('','docker_hub_creds')
                    {
                        
                        bat 'docker tag %LocalImage%:latest %Username%/%RemoteImage%:latest'
                        bat 'docker push %Username%/%RemoteImage%:latest'
                    }
                }
            }
        }
        
        stage('Remove local docker image')
        {
            steps{
                    bat 'docker rmi %LocalImage%'
            }
        }
         stage('Pull docker image')
        {
            steps{
                    bat 'docker pull %Username%/%RemoteImage%:latest'
            }
        }
         stage('Run docker image')
        {
            steps{
                    bat 'docker run  -d -p 14259:80 --name %ContainerName% %Username%/%RemoteImage%'
            }
        }
    }
    
}