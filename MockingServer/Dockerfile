FROM dockerfile/nodejs


RUN mkdir -p /app
COPY . /app
WORKDIR /app

EXPOSE 8080

ENTRYPOINT ["grunt"]