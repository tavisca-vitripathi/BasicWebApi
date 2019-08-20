pipeline {
    agent any

    stages {
        stage('Docker build') {
            steps {
				bat 'docker build -t vitripathi/basic_image:build-%BUILD_NUMBER% .'
            }
        }
		
		stage('Docker push'){
			steps{
				bat 'docker login -u vitripathi -p Fifa@kflt123'
				bat 'docker push vitripathi/basic_image:build-%BUILD_NUMBER%'
			}
		}
		
		stage('Docker run'){
			steps{
				bat 'docker run --rm -p 13250:80 vitripathi/basic_image:build-%BUILD_NUMBER%'
			}
		}
    }
}