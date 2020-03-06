#!/usr/bin/env python
# This Source Code Form is subject to the terms of the Mozilla Public
# License, v. 2.0. If a copy of the MPL was not distributed with this
# file, You can obtain one at http://mozilla.org/MPL/2.0/.
#
# Copyright 2019 (c) Kalycito Infotech Private Limited
# Copyright 2019 (c) fortiss GmbH, Stefan Profanter
#

import netifaces
import sys
import os
import socket
import argparse


parser = argparse.ArgumentParser(formatter_class=argparse.RawDescriptionHelpFormatter)

parser.add_argument('-k', '--key',
                    type=int,
                    dest="key_size",
                    default=2048,
                    help='Key size for the certificate')

parser.add_argument('--hostname',
                    default='',
                    help='Hostname included in the certificate. Default is set to the local hostname.')

parser.add_argument('-u', '--application-uri',
                    dest="application_uri",
                    default='urn:open62541.server.application',
                    help='Hostname included in the certificate. Default is set to the local hostname.')

parser.add_argument('outputDir',
                    metavar='<outputDir>',
                    help='The output directory for the generated certificate files')


args = parser.parse_args()


if not os.path.exists(args.outputDir):
    os.makedirs(args.outputDir)

keysize = args.key_size

hostname = args.hostname
if len(hostname) == 0:
    hostname = socket.gethostname()


scriptdir = os.path.dirname(os.path.abspath(__file__))

# Function return TRUE (1) when an IP address is associated with the
# given interface
def is_interface_up(interface):
    addr = netifaces.ifaddresses(interface)
    return netifaces.AF_INET in addr

# Initialize looping variables
interfaceNum = 0
iteratorValue = 0

# Read the number of interfaces available
numberOfInterfaces = int(format(len(netifaces.interfaces())))

# Traverse through the available network interfaces and store the
# corresponding IP addresses of the network interface in a variable
for interfaceNum in range(0, numberOfInterfaces):
    # Function call which returns whether the given
    # interface is up or not
    check = is_interface_up(netifaces.interfaces()[interfaceNum])

    # Check if the interface is up and not the loopback one
    # If yes set the IP Address for the environmental variables
    if check != 0 and netifaces.interfaces()[interfaceNum] != 'lo':
        if iteratorValue == 0:
            os.environ['IPADDRESS1'] = netifaces.ifaddresses(netifaces.interfaces()[interfaceNum])[netifaces.AF_INET][0]['addr']
        if iteratorValue == 1:
            os.environ['IPADDRESS2'] = netifaces.ifaddresses(netifaces.interfaces()[interfaceNum])[netifaces.AF_INET][0]['addr']
        iteratorValue = iteratorValue + 1
        if iteratorValue == 2:
            break

# If there is only one interface available then set the second
# IP address as loopback IP
if iteratorValue < 2:
    os.environ['IPADDRESS2'] = "127.0.0.1"

os.environ['HOSTNAME'] = hostname
os.environ['APP_URI'] = args.application_uri
openssl_conf = os.path.join(scriptdir, "ssl_host.cnf")

keyout = os.path.join(args.outputDir, hostname + ".key")
crtout = os.path.join(args.outputDir, hostname + ".crt")
cert_der = os.path.join(args.outputDir, hostname + "_cert.der")
key_der = os.path.join(args.outputDir, hostname + "_key.der")

os.chdir(os.path.abspath(args.outputDir))

os.system("""openssl req \
     -config {config_path} \
     -new \
     -nodes \
     -x509 -sha256  \
     -newkey rsa:{key_size} \
     -keyout "{keyout}" -days 3650 \
     -subj "/C=DE/O=fortiss {hostname}/CN={hostname}"\
     -out "{crtout}" """.format(config_path=openssl_conf, key_size=keysize, hostname=hostname, keyout=keyout, crtout=crtout))

os.system("""openssl x509 -in "{crtout}" -outform der -out "{cert_der}" """.format(crtout=crtout, cert_der=cert_der))
os.system("""openssl rsa -inform PEM -in "{keyout}" -outform DER -out "{key_der}" """.format(keyout=keyout, key_der=key_der))

#os.remove(keyout)
#os.remove(crtout)

print("Certificates generated in " + args.outputDir)
