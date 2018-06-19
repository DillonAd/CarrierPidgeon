pipeline {
    agent any
    
    stages {
        stage('Build') {
            steps {
                checkout scm
                sh 'dotnet build ./CarrierPidgeon.sln'
                stash "${BUILD_NUMBER}"
            }
        }
        stage('Unit Test') {
            steps {
                unstash "${BUILD_NUMBER}"
                sh 'dotnet /opt/sonarscanner-msbuild/SonarScanner.MSBuild.dll begin /k:"carrierPidgeon" /d:sonar.tests="./CarrierPidgeon.Test/" /d:sonar.exclusions="./CarrierPidgeon.Test/" /d:sonar.test.inclusions="./CarrierPidgeon.Test/"'
                sh 'dotnet build ./CarrierPidgeon.sln'
                sh 'dotnet test ./CarrierPidgeon.Test/CarrierPidgeon.Test.csproj --filter Category=unit --logger "trx;LogFileName=results\\tests_unit.xml" --no-build'
                sh 'dotnet /opt/sonarscanner-msbuild/SonarScanner.MSBuild.dll end'
                stash "${BUILD_NUMBER}"
            }
        }
    }
}