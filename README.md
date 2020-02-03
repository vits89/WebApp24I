# WebApp24I

This solution is the result of completing of a test task, conditions and explanations of which are given below.

---

Implement API service which will be an abstraction above messages queue framework. Service should receive http-requests with content of message which should be placed in queue, perform validation and then forward this message to queue. Initially RabbitMQ should be used as messages storage/processor. In future it could be changed.

Requirements for API service:
1. Add endpoint which will receive the following message parameters as json:
    1. Name of exchange to publish message. Validation:
        1. Required
        2. Max length: 30;
        3. Allow only letters, numbers and underscores. Value cannot start with underscore.
    2. Routing key. Validation:
        1. Required
        2. Max length: 30;
        3. Allow only letters, numbers, underscore and dot. Value cannot start with underscore or dot.
    3. Message data (custom json object).
2. RMQ connection and channel should be reused. RMQ connection should be launched on persistent basis and relaunched in case of error;
3. Use dependency injection with standard mechanism available in asp.net core framework;
4. Frameworks to use: Asp.Net Core, RabbitMQ.Client library.
