FROM gerritforge/gerrit-centos7
MAINTAINER GerritForge

USER gerrit
RUN git config -f /var/gerrit/etc/gerrit.config httpd.listenurl http://*:8090/
EXPOSE 29418 8090

# Start Gerrit
CMD /var/gerrit/bin/gerrit.sh start && tail -f /var/gerrit/logs/error_log