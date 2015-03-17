
angular.module('secPassXchange', [])
    .controller('passCtrl', function ($scope, $http) {

        $scope.reply = '<server reply comes here>';
        $scope.secret = '';
        $scope.enc = '';

        $scope.send = function () {
            $scope.reply = 'thinking..';

            // http://travistidwell.com/jsencrypt/
            var crypt = new JSEncrypt();
            crypt.setPublicKey('-----BEGIN PUBLIC KEY-----' + '\n'
                + 'MIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQDOFfwbqHOmQWYc50XxsR+dLyNU' + '\n'
                + 'SwsaQ3tx225AvYEOs9bSS3VVngL5z7nCaqLm0WFLqPs2Cncxzt6d6XkJVR78KDop' + '\n'
                + 'iYV1v5Qq3JngrzZHaoj7qJpd8bJQpWcMcgviPjJnkWwa0FMUsxPOhEfdw8EfFxla' + '\n'
                + 'XJhrmjPD3Yoq8NqBAwIDAQAB' + '\n'
                + '-----END PUBLIC KEY-----' + '\n');

            var enc = crypt.encrypt($scope.secret);

            $scope.enc = enc;

            
            $http({
                method: 'POST',
                url: '/api/sec',
                data: { password: $scope.enc },
                headers: {
                    'Content-Type' : 'application/json'
                }
            }).success(function(data) {
                $scope.reply = data;
                $scope.secret = '';
            });
            
        };

    });


