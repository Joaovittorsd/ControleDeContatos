# Controle De Contatos

# Branch Hotfix

A branch `hotfix` é usada para resolver problemas críticos ou bugs urgentes encontrados no ambiente de produção que precisam ser corrigidos imediatamente.

## Propósito

Esta branch é criada a partir da `main` para lidar com correções que não podem esperar até a próxima versão planejada. Ela permite que a equipe aborde problemas críticos de maneira isolada, sem interromper o desenvolvimento normal na `dev`.

## Como Utilizar

Quando um problema crítico é identificado em produção e requer uma correção imediata, uma nova branch `hotfix` é criada a partir da `main`. Após a correção do problema, o código é testado e revisado antes de ser mesclado de volta para `main` e possivelmente para `dev`, dependendo da gravidade do problema.

É fundamental manter as alterações na `hotfix` o mais minimalistas possível, focando apenas na resolução do problema urgente, para garantir a estabilidade do ambiente de produção enquanto mantém a coesão com o fluxo de desenvolvimento regular.
