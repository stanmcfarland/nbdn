function merge($working_branch,$branch_to_merge)
{
  git checkout $working_branch
  git merge $branch_to_merge
}

function delete_branch($branch)
{
  git branch -D $branch 
}

function checkout($branch)
{
   git checkout $branch

   if ($LastExitCode -ne 0)
   {
     git checkout -b $branch
   }
  
}

function commit($message)
{
  git add -A
  if ($message -eq $null)
  {
    git commit
    return
  }
  git commit -m $message
}

function push($branch)
{
  if ($branch -eq $null)
  {
    git push
    return
  }
  git push origin $branch
}

function pull($remote,$remote_branch)
{
  git pull $remote $remote_branch
}

