#!/bin/bash
if !(git rev-parse --is-inside-work-tree > /dev/null 2>&1;) then
  echo "!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!"
  echo "* Not inside a Git working directory !"
  echo "* Processing terminating             !"
  echo "!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!"
  exit
fi
  echo "*************************************"
  echo "* Looks like you in a git directory *"
  echo "* Processing continues              *"
  echo "*************************************"
  git config --global --unset pull.rebase
  git remote remove frankscode
  git remote add frankscode https://github.com/grandcircusco/CSharpAHBC-March-2025-Code.git
  git config --global core.editor "code -w -n"
  git config --global merge.tool "merge --no-edit"
  git pull frankscode main --allow-unrelated-histories
  git remote -v
 