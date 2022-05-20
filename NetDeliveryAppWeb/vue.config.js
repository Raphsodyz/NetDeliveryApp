const fs = require('fs')
const path = require('path')

const baseFolder =
    process.env.APPDATA !== undefined && process.env.APPDATA !== ''
        ? `${process.env.APPDATA}/ASP.NET/https`
        : `${process.env.HOME}/.aspnet/https`;

const certificateArg = process.argv.map(arg => arg.match(/--name=(?<value>.+)/i)).filter(Boolean)[0];
const certificateName = certificateArg ? certificateArg.groups.value : "netdeliveryappweb";

if (!certificateName) {
    console.error('Invalid certificate name. Run this script in the context of an npm/yarn script or pass --name=<<app>> explicitly.')
    process.exit(-1);
}

const certFilePath = path.join(baseFolder, `${certificateName}.pem`);
const keyFilePath = path.join(baseFolder, `${certificateName}.key`);

module.exports = {
    devServer: {
        https: {
            key: fs.readFileSync(keyFilePath),
            cert: fs.readFileSync(certFilePath),
        },
        proxy: {
            '^/Acrescimos/Listar': {
                target: 'https://localhost:5001/api/'
            },
            '^/Acrescimos/Encontrar/': {
                target: 'https://localhost:5001/api/'
            },
            '^/Acrescimos/Editar/': {
                target: 'https://localhost:5001/api/'
            },
            '^/Acrescimos/Adicionar': {
                target: 'https://localhost:5001/api/'
            },
            '^/Acrescimos/Deletar/': {
                target: 'https://localhost:5001/api/'
            },
            '^/Categorias/Listar': {
                target: 'https://localhost:5001/api/'
            },
            '^/Categorias/Encontrar/': {
                target: 'https://localhost:5001/api/'
            },
            '^/Categorias/Editar/': {
                target: 'https://localhost:5001/api/'
            },
            '^/Categorias/Adicionar': {
                target: 'https://localhost:5001/api/'
            },
            '^/Categorias/Deletar/': {
                target: 'https://localhost:5001/api/'
            },
            '^/Enderecos/Listar': {
                target: 'https://localhost:5001/api/'
            },
            '^/Enderecos/Encontrar/': {
                target: 'https://localhost:5001/api/'
            },
            '^/Enderecos/Editar/': {
                target: 'https://localhost:5001/api/'
            },
            '^/Enderecos/Adicionar': {
                target: 'https://localhost:5001/api/'
            },
            '^/Enderecos/Deletar/': {
                target: 'https://localhost:5001/api/'
            },
            '^/Pedidos/Listar': {
                target: 'https://localhost:5001/api/'
            },
            '^/Pedidos/Encontrar/': {
                target: 'https://localhost:5001/api/'
            },
            '^/Pedidos/Editar/': {
                target: 'https://localhost:5001/api/'
            },
            '^/Pedidos/Adicionar': {
                target: 'https://localhost:5001/api/'
            },
            '^/Pedidos/Deletar/': {
                target: 'https://localhost:5001/api/'
            },
            '^/Produtos/Listar': {
                target: 'https://localhost:5001/api/'
            },
            '^/Pedidos/Encontrar/': {
                target: 'https://localhost:5001/api/'
            },
            '^/Pedidos/Editar/': {
                target: 'https://localhost:5001/api/'
            },
            '^/Pedidos/Adicionar': {
                target: 'https://localhost:5001/api/'
            },
            '^/Pedidos/Deletar/': {
                target: 'https://localhost:5001/api/'
            },
            '^/Pedidos/Listar': {
                target: 'https://localhost:5001/api/'
            },
            '^/Usuarios/Encontrar': {
                target: 'https://localhost:5001/api/'
            },
            '^/Usuarios/Registro': {
                target: 'https://localhost:5001/api/'
            },
            '^/Usuarios/Login': {
                target: 'https://localhost:5001/api/'
            }
        },
        port: 5002
    }
}